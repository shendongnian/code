     public static class CommonCommands
    {
        private static ICommand dropDownButtonLoadedCommand;
        private static ICommand dropDownButtonMouseEnterCommand;
        public static ICommand DropDownButtonLoadedCommand => dropDownButtonLoadedCommand;
        public static ICommand DropDownButtonMouseEnterCommand => dropDownButtonMouseEnterCommand;
        static CommonCommands()
        {
            dropDownButtonLoadedCommand = new RelayCommand<RoutedEventArgs>(DropDownButtonLoaded, x => true);
            dropDownButtonMouseEnterCommand = new RelayCommand<MouseEventArgs>(DropDownButtonMouseEnter, x => true);
        }
        private static void DropDownButtonLoaded(RoutedEventArgs args)
        {
            var dropDownButton = args.Source as DropDownButton;
            if (dropDownButton != null)
            {
                var template = dropDownButton.Template;
                var menu = (ContextMenu)template.FindName("PART_Menu", dropDownButton);
                var button = (Button)template.FindName("PART_Button", dropDownButton);
                menu.MouseLeave += (o, e) =>
                {
                    if (dropDownButton.IsExpanded && !dropDownButton.IsMouseOver && !menu.IsMouseOver)
                    {
                        dropDownButton.IsExpanded = false;
                    }
                };
                menu.PreviewMouseMove += (o, e) =>
                {
                    if (!dropDownButton.IsExpanded || !menu.IsOpen)
                    {
                        return;
                    }
                    var x = e.GetPosition(menu).X;
                    var y = e.GetPosition(menu).Y;
                    if (x < 0 | y < -button.ActualHeight | x > menu.ActualWidth | y > menu.ActualHeight)
                    {
                        menu.ReleaseMouseCapture();
                    }
                };
            }
        }
        private static void DropDownButtonMouseEnter(MouseEventArgs args)
        {
            var dropDownButton = args.Source as DropDownButton;
            if (dropDownButton != null && !dropDownButton.IsExpanded)
            {
                dropDownButton.IsExpanded = true;
            }
        }
    }
