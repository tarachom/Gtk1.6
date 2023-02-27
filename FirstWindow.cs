using Gtk;

namespace GtkTest;

class FirstWindow : Window
{
    public FirstWindow() : base("GtkTest")
    {
        SetDefaultSize(1200, 900);
        SetPosition(WindowPosition.Center);
        BorderWidth = 5;

        DeleteEvent += delegate { Program.Quit(); };

        //Основний контейнер
        VBox vBox = new VBox();
        Add(vBox);

        //Меню
        {
            MenuBar mb = new MenuBar();
            vBox.PackStart(mb, false, false, 0);

            //1
            Menu OneMenu = new Menu();
            MenuItem Item = new MenuItem("Файл");
            Item.Submenu = OneMenu;

            MenuItem save = new MenuItem("Зберегти");
            OneMenu.Append(save);

            MenuItem edit = new MenuItem("Параметри");
            OneMenu.Append(edit);

            mb.Append(Item);

            //2
            Menu TooMenu = new Menu();
            MenuItem Item2 = new MenuItem("Користувачі");
            Item2.Submenu = TooMenu;

            MenuItem usersList = new MenuItem("Список користувачів");
            TooMenu.Append(usersList);

            mb.Append(Item2);
        }

        //Верхній горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            Button bOk = new Button("OK");
            hBox.PackStart(new Label("OK"), false, false, 2);
            hBox.PackStart(bOk, false, false, 2);

            Button bClose = new Button("Close");
            hBox.PackEnd(new Label("Close"), false, false, 2);
            hBox.PackEnd(bClose, false, false, 2);
        }

        //Другий горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            //Поле Назва
            Entry name = new Entry();
            hBox.PackStart(new Label("Назва:"), false, false, 2);
            hBox.PackStart(name, false, false, 2);

            //Вибір із випадаючого списку
            Dictionary<string, string> comboBoxData = new Dictionary<string, string>();
            comboBoxData.Add("1", "Один");
            comboBoxData.Add("2", "Два");
            comboBoxData.Add("3", "Три");

            ComboBoxText comboBoxText = new ComboBoxText();
            foreach (var item in comboBoxData)
                comboBoxText.Append(item.Key, item.Value);

            comboBoxText.Active = 0;

            hBox.PackStart(new Label("Тип:"), false, false, 2);
            hBox.PackStart(comboBoxText, false, false, 2);
        }

        //Третій горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            //Набір даних
            Dictionary<string, string> comboBoxData = new Dictionary<string, string>();
            comboBoxData.Add("1", "Один");
            comboBoxData.Add("2", "Два");
            comboBoxData.Add("3", "Три");
            comboBoxData.Add("4", "Два");
            comboBoxData.Add("5", "Три");
            comboBoxData.Add("6", "Один");
            comboBoxData.Add("7", "Два");
            comboBoxData.Add("8", "Три");
            comboBoxData.Add("9", "Два");
            comboBoxData.Add("10", "Три");

            ListBox listBox = new ListBox();

            ScrolledWindow scroll = new ScrolledWindow() { WidthRequest = 200, HeightRequest = 200, ShadowType = ShadowType.In };
            scroll.SetPolicy(PolicyType.Never, PolicyType.Automatic);
            scroll.Add(listBox);

            foreach (var item in comboBoxData)
            {
                ListBoxRow row = new ListBoxRow() { Name = item.Key };
                row.Add(new Label($"<b>{item.Value}</b>") { Halign = Align.Start, UseMarkup = true });

                listBox.Add(row);
            }

            hBox.PackStart(new Label("Список:") { Valign = Align.Start }, false, false, 2);
            hBox.PackStart(scroll, false, false, 2);
        }

        //Четвертий горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            Switch sswitch = new Switch();

            hBox.PackStart(new Label("Переключатель"), false, false, 2);
            hBox.PackStart(sswitch, false, false, 2);

            CheckButton checkButton = new CheckButton("Активовано");
            hBox.PackStart(checkButton, false, false, 10);
        }

        //П'ятий горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            Toolbar toolbar = new Toolbar();

            ToolButton addButton = new ToolButton(Stock.Add) { Label = "Додати", IsImportant = true, TooltipText = "Додати" };
            toolbar.Add(addButton);

            ToolButton upButton = new ToolButton(Stock.Edit) { Label = "Редагувати", IsImportant = true, TooltipText = "Редагувати" };
            toolbar.Add(upButton);

            ToolButton copyButton = new ToolButton(Stock.Copy) { Label = "Копіювати", IsImportant = true, TooltipText = "Копіювати" };
            toolbar.Add(copyButton);

            ToolButton deleteButton = new ToolButton(Stock.Delete) { Label = "Видалити", IsImportant = true, TooltipText = "Видалити" };
            toolbar.Add(deleteButton);

            ToolButton refreshButton = new ToolButton(Stock.Refresh) { Label = "Обновити", IsImportant = true, TooltipText = "Обновити" };
            toolbar.Add(refreshButton);

            hBox.PackStart(toolbar, false, false, 2);
        }

        //Шостий горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            Separator separator = new Separator(Orientation.Horizontal);

            hBox.PackStart(separator, true, true, 2);
        }

        //Сьомий горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            Button bPopover = new Button("Календар");

            Popover popover = new Popover(bPopover) { Position = PositionType.Right, BorderWidth = 5 };
            popover.Add(new Calendar());

            bPopover.Clicked += (object? sender, EventArgs args) => { popover.ShowAll(); };

            hBox.PackStart(bPopover, false, false, 2);
        }

        //Восьмий горизонтальний контейнер
        {
            Menu PopUpContextMenu()
            {
                Menu menu = new Menu();

                MenuItem open = new MenuItem("Відкрити");
                menu.Append(open);

                MenuItem close = new MenuItem("Закрити");
                menu.Append(close);

                menu.ShowAll();

                return menu;
            }

            HBox hBox = new HBox();
            vBox.PackStart(hBox, false, false, 5);

            Button bPopUp = new Button("Спливаюче меню");

            bPopUp.ButtonReleaseEvent += (object? sender, ButtonReleaseEventArgs args) =>
            {
                //if (args.Event.Button == 3)
                    PopUpContextMenu().Popup();
            };

            hBox.PackStart(bPopUp, false, false, 2);
        }

        //Дев'ятий горизонтальний контейнер
        {
            Menu PopUpContextMenu()
            {
                Menu menu = new Menu();

                MenuItem open = new MenuItem("Додати");
                menu.Append(open);

                MenuItem close = new MenuItem("Видалити");
                menu.Append(close);

                menu.ShowAll();

                return menu;
            }

            void AddColumns(TreeView TreeViewGrid)
            {
                TreeViewGrid.AppendColumn(new TreeViewColumn("", new CellRendererPixbuf(), "pixbuf", 0)); /* Image */
                TreeViewGrid.AppendColumn(new TreeViewColumn("Код", new CellRendererText() { Xpad = 4 }, "text", 1)); /* Код */
                TreeViewGrid.AppendColumn(new TreeViewColumn("Назва", new CellRendererText() { Xpad = 4 }, "text", 2)); /* Назва */
                TreeViewGrid.AppendColumn(new TreeViewColumn());
            }

            void FillStore(ListStore listStore)
            {
                List<Array> list = new List<Array>();

                var pb = new Gdk.Pixbuf("images/ok.png");

                for (int i = 0; i < 20; i++)
                    list.Add(new object[] { pb, $"{i}", $"Назва {i}" });

                foreach (var item in list)
                    listStore.AppendValues(item);
            }

            HBox hBox = new HBox();
            vBox.PackStart(hBox, true, true, 5);

            ListStore listStore = new ListStore
            (
                typeof(Gdk.Pixbuf) /* Image */,
                typeof(string)     /* Код */,
                typeof(string)     /* Назва */
            );

            ScrolledWindow scrollTree = new ScrolledWindow() { ShadowType = ShadowType.In };
            scrollTree.SetPolicy(PolicyType.Never, PolicyType.Automatic);

            TreeView TreeViewGrid = new TreeView(listStore);
            AddColumns(TreeViewGrid);

            TreeViewGrid.Selection.Mode = SelectionMode.Multiple;
            TreeViewGrid.ActivateOnSingleClick = true;
            TreeViewGrid.ButtonReleaseEvent += (object? sender, ButtonReleaseEventArgs args) =>
            {
                if (args.Event.Button == 3 && TreeViewGrid.Selection.CountSelectedRows() != 0)
                    PopUpContextMenu().Popup();
            }; ;

            scrollTree.Add(TreeViewGrid);

            hBox.PackStart(scrollTree, true, true, 2);

            FillStore(listStore);
        }

        //Нижній горизонтальний контейнер
        {
            HBox hBox = new HBox();
            vBox.PackEnd(hBox, false, false, 5);

            Button bOk = new Button("OK");
            hBox.PackStart(new Label("OK"), false, false, 2);
            hBox.PackStart(bOk, false, false, 2);

            Button bClose = new Button("Close");
            hBox.PackEnd(new Label("Close"), false, false, 2);
            hBox.PackEnd(bClose, false, false, 2);
        }

        ShowAll();
    }
}
