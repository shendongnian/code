    class Properties : IDictionary<string, string>
    {
        private Dictionary<string, string> _staticProps;
        private Dictionary<string, string> _otherProps;
        public Properties()
        {
            _staticProps = new Dictionary<string, string>
            {
                {"Name", "" },
                {"Number", "" },
                {"Age", "" }
            };
            _otherProps = new Dictionary<string, string>();
        }
        public ICollection<string> Keys
        {
            get
            {
                return (ICollection<String>)_otherProps.Keys.Concat(_staticProps.Keys);
            }
        }
        public ICollection<string> Values
        {
            get
            {
                return (ICollection<String>)_otherProps.Values.Concat(_staticProps.Values);
            }
        }
        public int Count
        {
            get
            {
                return _otherProps.Count + _staticProps.Count;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public string this[string key]
        {
            get
            {
                if (_otherProps.ContainsKey(key))
                {
                    return _otherProps[key];
                }
                if(_staticProps.ContainsKey(key))
                {
                    return _staticProps[key];
                }
                throw new KeyNotFoundException(key);
            }
            set
            {
                if (_otherProps.ContainsKey(key) || _staticProps.ContainsKey(key))
                {
                    throw new ArgumentException("key exists: " + key);
                }
                _otherProps[key] = value;
            }
        }
        public bool ContainsKey(string key)
        {
            return _otherProps.ContainsKey(key) || _staticProps.ContainsKey(key);
        }
        public void Add(string key, string value)
        {
            _otherProps.Add(key, value);
        }
        public bool Remove(string key)
        {
            if (_staticProps.ContainsKey(key))
            {
                throw new ArgumentException("key is static, cannot be removed: " + key);
            }
            return _otherProps.Remove(key);
        }
        public bool TryGetValue(string key, out string value)
        {
            return _otherProps.TryGetValue(key, out value) || _staticProps.TryGetValue(key, out value);
        }
        public void Add(KeyValuePair<string, string> item)
        {
            if (_staticProps.ContainsKey(item.Key))
            {
                throw new ArgumentException("key exist an is static: " + item.Key);
            }
            _otherProps.Add(item.Key, item.Value);
        }
        public void Clear()
        {
            _otherProps.Clear();
            foreach (var key in _staticProps.Keys)
            {
                _staticProps[key] = string.Empty;
            }
        }
        public bool Contains(KeyValuePair<string, string> item)
        {
            return _otherProps.Contains(item) || _staticProps.Contains(item);
        }
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {           
            // define yourself how you want to handle arrayIndex between the two dictionaries
        }
        public bool Remove(KeyValuePair<string, string> item)
        {
            if (_staticProps.ContainsKey(item.Key))
            {
                throw new ArgumentException("key is static, cannot be removed: " + item.Key);
            }
            return _otherProps.Remove(item.Key);
        }
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _otherProps.Concat(_staticProps).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _otherProps.Concat(_staticProps).GetEnumerator();
        }
    }
