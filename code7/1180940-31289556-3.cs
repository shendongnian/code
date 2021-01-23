        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var target = (sender as Button)?.Tag as TextBox;
            if (target != null)
            {
                ...
            }
        }
