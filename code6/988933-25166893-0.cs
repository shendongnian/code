    class Test
    {
        Dictionary<string,object> _values = new Dictionary<string, object>();
        public string Foo
        {
            get
            {
                var value = GetValue();
                return value == null ? string.Empty : (string)value;
            }
            set
            {
                SetValue(value);
            }
        }
        private object GetValue()
        {
            var stack = new StackTrace();
            var key = GetGenericName(stack.GetFrame(1).GetMethod().Name);
            if (_values.ContainsKey(key)) return _values[key];
            return null;
        }
        private void SetValue(object value)
        {
            var stack = new StackTrace();
            var key = GetGenericName(stack.GetFrame(1).GetMethod().Name);
            _values[key] = value;
        }
        private string GetGenericName(string key)
        {
            return key.Split('_')[1];
        }
    }
