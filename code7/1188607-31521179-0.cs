        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> oldItemNames = new List<string>();
            foreach(var item in e.RemovedItems)
            {
                oldItemNames.Add(item.ToString());
            }
        }
