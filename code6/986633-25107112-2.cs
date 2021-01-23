        private void ListViewLoaded(object sender, RoutedEventArgs e)
        {
            var lv = sender as ListView;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(2);
            dt.Tick += (o, o1) =>
            {
                dt.Stop();
                lv.ScrollIntoView(lv.Items[50]);
            };
            dt.Start();
        }
