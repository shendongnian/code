        private bool _isAdded;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!_isAdded)
            {
                var button = new AppBarButton();
                button.Icon = new SymbolIcon(Symbol.Find);
                bottomCommandBar.PrimaryCommands.Add(button);
            }
            else
            {
                bottomCommandBar.PrimaryCommands.RemoveAt(bottomCommandBar.PrimaryCommands.Count - 1);
            }
            _isAdded = !_isAdded;
        }
