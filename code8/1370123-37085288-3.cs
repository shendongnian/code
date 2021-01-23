    internal static void FindChildren<T>(List<T> results, DependencyObject startNode) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(startNode);
        for (int i = 0; i < count; i++)
        {
            DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
            if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
            {
                T asType = (T)current;
                results.Add(asType);
            }
            FindChildren<T>(results, current);
        }
    }
    
