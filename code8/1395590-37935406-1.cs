    static class MyExtensions
    {
        public static object ForceExpand<T> (this T value)
            => value == null ? null : new Expanded<T> (value);
    
        class Expanded<T> : ICustomMemberProvider
        {
            object _instance;
            PropertyInfo[] _props;
    
            public Expanded (object instance)
            {
                _instance = instance;
                _props = _instance.GetType().GetProperties();
            }
    
            public IEnumerable<string> GetNames() => _props.Select (p => p.Name);
            public IEnumerable<Type> GetTypes () => _props.Select (p => p.PropertyType);
            public IEnumerable<object> GetValues () => _props.Select (p => p.GetValue (_instance));
        }
    }
