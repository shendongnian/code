     private void cacheList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                ListViewItem selectedItem = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                Image image = FindElementInVisualTree<Image>(selectedItem);
                if (image != null)
                {
                    image.Visibility = Visibility.Visible;
                }
                FindListViewItem((sender as ListView), selectedItem);
            }
        }
        private void FindListViewItem(DependencyObject parent,ListViewItem selectedItem)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is ListViewItem && (child as ListViewItem) != selectedItem)
                {
                    Image unselectedimage = FindElementInVisualTree<Image>(child);
                    if (unselectedimage != null)
                    {
                        unselectedimage.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                  FindListViewItem(child, selectedItem);
                }
            }
        }
