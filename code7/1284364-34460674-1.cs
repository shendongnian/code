        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ComboBoxItem selectedItem = cb.SelectedItem as ComboBoxItem;
            
            switch (selectedItem.Tag.ToString())
            {
                case "SW":
                    //first item selected...
                    break;
                case "FSW":
                    // Second item selected..
                    break;
                case "QW":
                    break;
            }
        }
