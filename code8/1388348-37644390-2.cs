    class Account
    {
        private Dictionary<string, object> _fields = new Dictionary<Type, object>();
        public void Set(string name, object data)
        {
            _fields[name] = data;
        }
        public T Get<T>(string name)
        {
            object data = null;
            if (_fields.TryGetValue(type, out data))
                return (T)data;
            return default(T);
        }
    }
