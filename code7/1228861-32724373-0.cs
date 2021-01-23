    public static class AppHelpers
    {
        public static List<T> GetVisualChildCollection<T>(object parent) where T : Control
        {
            List<T> visualCollection = new List<T>();
            GetVisualChildCollection((DependencyObject)parent, visualCollection);
            return visualCollection;
        }
        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : Control
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }
    }
