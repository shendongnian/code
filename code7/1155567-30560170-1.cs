    class PropertyCaller<T>
    {
        // Static for each type T
        private static readonly IDictionary<string, Func<T, object>> _propertyLookup;
        static PropertyCaller()
        {
            _propertyLookup = new Dictionary<string, Func<T, object>>();
            Type objectType = typeof (T);
            IList<PropertyInfo> props = new List<PropertyInfo>(objectType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                const BindingFlags num = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
                MethodInfo getMethod = prop.GetGetMethod(true);
                _propertyLookup.Add(prop.Name, item => getMethod.Invoke(item, num, null, null, null));
            }
        }
        public static object Call(T obj, string propertyName)
        {
            Func<T, object> f;
            
            if (!_propertyLookup.TryGetValue(propertyName, out f))
            {
                throw new InvalidOperationException();
            }
            
            return f(obj);
        }
    }
