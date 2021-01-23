       private void cbFirst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (selIndex != null)
            {
                cbSecond.ItemsSource = null;
                IEnumerable<string> str = GetSubItems(cbFirst.SelectedIndex);
                cbSecond.ItemsSource = str;
            }
        }
