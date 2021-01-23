    private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = ((CheckBox) sender);
            if (checkBox.IsChecked != null && checkBox.IsChecked.Value)
            {
                MyExpander.Header = checkBox.Content.ToString();
            }
        }
