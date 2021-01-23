        private void TreeViewControl_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Item)
            {
                Item item = e.NewValue as Item;
                if (Item != SelectedItem)
                {
                    //keep SelectedItem in sync with Treeview.SelectedItem
                    SelectedItem = e.NewValue as Item;
                }
            }
            else
            {
                var item = e.NewValue as HierarchicalGroup;
                item.IsExpanded = true;
                if (item.Children.Count() > 0)
                {
                    if (item.Children[0] is Item)
                    {
                        (item.Children[0] as Item).IsSelected = true;
                    }
                }
            }
        }
