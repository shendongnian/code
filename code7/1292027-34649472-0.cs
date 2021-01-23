     private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                data.Items.Add("test");
                data.Items.Add("test1");
            }   
    
            private void data_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
            {
                data.SelectedValue = data.SelectedItem.ToString();
            }
