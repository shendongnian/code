        private void OwnerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var addedItem = e.AddedItems.Cast<Model>().ToList();
                foreach(var item in addedItem)
                {
                    item.IsSelected = true;
                }
            }
            if (e.RemovedItems != null && e.RemovedItems.Count > 0)
            {
                var removedItems = e.RemovedItems.Cast<Model>().ToList();
                foreach (var item in removedItems)
                {
                    item.IsSelected = false;
                }
            }
        }
