    private DependencyObject GetDependencyObjectFromVisualTree(DependencyObject startObject, Type type)
            {              
                DependencyObject parent = startObject;
                while (parent != null)
                {
                    if (type.IsInstanceOfType(parent))
                        break;
                    else
                        parent = VisualTreeHelper.GetParent(parent);
                }
                return parent;
            }
    
    
            private void Delete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                var selectedItem = GetDependencyObjectFromVisualTree(e.OriginalSource as DependencyObject, typeof(ListViewItem)) as ListViewItem;      
    //here you can use it to traverse your vm.Cities list to update it or do anything.
               System.Diagnostics.Debug.WriteLine(((YourModel)selectedItem.Content).Cities);
            }
