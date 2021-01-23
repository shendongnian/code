    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (PivotHeaderItem phItem in FindVisualChildren<PivotHeaderItem(mainPivot))
         {
             phItem.Height = 110;
        }
    }
    //Find all children
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
