    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
    
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    
    
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var test = FindVisualChildren<TreeViewItem>(tvEmps);
            List<TreeViewItem> objtreeList = new List<TreeViewItem>();
            foreach (var item in test)
            {
                var chec = FindVisualChildren<CheckBox>(item as TreeViewItem).Cast<CheckBox>();
                if ((chec.FirstOrDefault() as CheckBox).IsChecked == true)
                {
                    var textblock = FindVisualChildren<TextBlock>(item as TreeViewItem);
                }
            }
        }
