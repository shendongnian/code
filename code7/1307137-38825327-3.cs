    public class View
    {
        private readonly Dictionary<string, Dictionary<string, object>> _views = new Dictionary<string, Dictionary<string, object>>();
        private static readonly View _instance = new View();
        public static View State => _instance;
        public Dictionary<string, object> this[string viewKey]
        {
            get
            {
                if (_views.ContainsKey(viewKey))
                {
                    return _views[viewKey];
                }
                return null;
            }
            set
            {
                _views[viewKey] = value;
            }
        }
        public Dictionary<string, object> this[Type viewType]
        {
            get
            {
                return this[viewType.FullName];
            }
            set
            {
                this[viewType.FullName] = value;
            }
        }
    }
    public static class Extensions
    {
        public static T GetChildOfType<T>(this DependencyObject depObj)
    where T : DependencyObject
        {
            if (depObj == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
    }
