    List<string> selecteditems = new List<string>();
     private void CheckBox_Click(object sender, RoutedEventArgs e)
            {
                var cb = sender as CheckBox;
                if (cb.IsChecked == true)
                {
                    var item = cb.DataContext;
                    selecteditems.Add(item.ToString());
                }
                else
                {
                    var item = cb.DataContext;
                    selecteditems.Remove(item.ToString());
                }
            }
