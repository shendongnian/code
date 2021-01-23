    IsolatedStorageSettings Store { get { return IsolatedStorageSettings.ApplicationSettings; } }
        public T GetValue<T>(string key)
        {
            return (T)Store[key];
        }
        public void SetValue(string token, object value)
        {
            Store.Add(token, value);
            Store.Save();
        }
