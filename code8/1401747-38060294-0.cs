        private void userType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var comboBoxItem = comboBox.SelectedItem as ComboBoxItem;
                if (comboBoxItem != null)
                {
                    var content = comboBoxItem.Content;
                    System.Diagnostics.Debug.WriteLine(content);
                }
            }
        }
