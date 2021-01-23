      private void treeviewpaneL_SelectedItemChanged(object sender,   RoutedPropertyChangedEventArgs<object> e)
            {
                MyTreeViewItem selectedItem = e.NewValue as MyTreeViewItem;
                if (selectedItem != null) 
                {
                    MessageBox.Show("" + selectedItem.Index);
                
                }
            }
