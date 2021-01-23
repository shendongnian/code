    public static List<T> FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            List<T> childItems = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                if (childItems == null)
                    childItems = new List<T>();
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    childItems.Add((T)child);
                }
                var recursiveChildItems = FindVisualChild<T>(child);
                if (recursiveChildItems != null && recursiveChildItems.Count > 0)
                    childItems.AddRange(recursiveChildItems);
            }
            return childItems;
        }
        return null;
    }
