    class Properties : IDictionary<string, string>
    {
        private Dictionary<string, string> _staticKeys;
        private Dictionary<string, string> _allKeys;
        public Properties()
        {
            _staticKeys = new Dictionary<string, string>
            {
                {"Name", "" },
                {"Number", "" },
                {"Age", "" }
            };
            _allKeys = new Dictionary<string, string>();
        }
        public ICollection<string> Keys
        {
            get
            {
                return (ICollection<String>)_allKeys.Keys.Concat(_staticKeys.Keys);
            }
        }
        public ICollection<string> Values
        {
            get
            {
                return (ICollection<String>)_allKeys.Values.Concat(_staticKeys.Values);
            }
        }
        public int Count
        {
            get
            {
                return _allKeys.Count + _staticKeys.Count;
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
                if (_allKeys.ContainsKey(key))
                {
                    return _allKeys[key];
                }
                if(_staticKeys.ContainsKey(key))
                {
                    return _staticKeys[key];
                }
                throw new KeyNotFoundException(key);
            }
            set
            {
                if (_allKeys.ContainsKey(key) || _staticKeys.ContainsKey(key))
                {
                    throw new ArgumentException("key exists: " + key);
                }
                _allKeys[key] = value;
            }
        }
        public bool ContainsKey(string key)
        {
            return _allKeys.ContainsKey(key) || _staticKeys.ContainsKey(key);
        }
        public void Add(string key, string value)
        {
            _allKeys.Add(key, value);
        }
        public bool Remove(string key)
        {
            if (_staticKeys.ContainsKey(key))
            {
                throw new ArgumentException("key is static, cannot be removed: " + key);
            }
            return _allKeys.Remove(key);
        }
        public bool TryGetValue(string key, out string value)
        {
            throw new NotImplementedException();
        }
        public void Add(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
