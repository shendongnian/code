      private void Address_Expander_Expanded(object sender, RoutedEventArgs e)
            {
                var s = e.OriginalSource as FrameworkElement;
                var expander = s as RadExpander;
                if (expander != null)
                {
                    var parentRow = s.ParentOfType<DataGridRow>();
                    if (parentRow != null)
                    {
                        parentRow.IsSelected = true;
                        parentRow.DetailsVisibility = Visibility.Visible;
                    }
                }
    
            }
    
            private void Address_Expander_Collapsed(object sender, RoutedEventArgs e)
            {
                var s = e.OriginalSource as FrameworkElement;
                var expander = s as RadExpander;
                if (expander != null)
                {
                    var parentRow = s.ParentOfType<DataGridRow>();
                    if (parentRow != null)
                    {
                        parentRow.IsSelected = false;
                        parentRow.DetailsVisibility = Visibility.Collapsed;
                    }
                }
    
            }
