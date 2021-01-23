        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 3; i++)
            {
                var item = new TabItem {Header = i.ToString(), Name = $"tab{i}"};
                TabMain.Items.Add(item);
            }
        }
