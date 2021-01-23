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
                    var count = VisualTreeHelper.GetChildrenCount(sender as ListView);
                    for (int i = 0; i < count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(sender as ListView, i);
                        if(child is ListViewItem && (child as ListViewItem) != selectedItem)
                        {
                            Image unselectedimage = FindElementInVisualTree<Image>(child);
                            if(unselectedimage!=null)
                            {
                                unselectedimage.Visibility = Visibility.Collapsed;
                            }
                        }
                       
                    }
                }
            }
