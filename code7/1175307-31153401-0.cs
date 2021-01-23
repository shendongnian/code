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
    
        private static bool GetLogicalChildCollection(DependencyObject parent)
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is CheckBox)
                    {
                        return true;
                    }
    
                    GetLogicalChildCollection(depChild);
                }
            }
    
            return false;
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
