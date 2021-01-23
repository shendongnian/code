    static class Utils
    {
        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj)
               where T : DependencyObject
        {
            ...
        }
        public static childItem FindVisualChild<childItem>(this DependencyObject obj)
            where childItem : DependencyObject
        {
            ...
        }
    }
