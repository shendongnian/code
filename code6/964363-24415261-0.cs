    public static class DependentObjectExtensions
    {
        public static IEnumerable<DependencyObject> GetChildren(this DependencyObject parent)
        {
            for (int i = 0, length = VisualTreeHelper.GetChildrenCount(parent); i < length; i++)
            {
                yield return VisualTreeHelper.GetChild(parent, i);
            }
        }
        public static T FindChild<T>(this DependencyObject parent, string name, bool drillDown = false)
            where T : FrameworkElement
        {
            if(parent != null)
            {
                var elements = parent.GetChildren().OfType<T>();
                return drillDown
                    ? elements.Select(x => FindChild<T>(x, name, true)).FirstOrDefault(x => x != null)
                    : elements.FirstOrDefault(x => x.Name == name);
            }
            return null;
        }
    }
