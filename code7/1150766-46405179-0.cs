        Profiles.Click += profileClick;
        private void profileClick (object sender, RoutedEventArgs e) {
             MenuItem item = e.OriginalSource as MenuItem;
             //you can use item.Name and item.Header to identify the MenuItem
        }
