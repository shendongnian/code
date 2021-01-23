        public string this[string key]
        {
            get
            {
                string value;
                _settingsDictionary.TryGetValue(key, out value);
                if (string.IsNullOrEmpty(value)) return string.Empty;
                return value.Decrypt(ENCKEY);
            }
            set
            {
                if (string.IsNullOrEmpty(value)) _settingsDictionary.Remove(key);
                else _settingsDictionary[key] = value.Encrypt(ENCKEY);
            }
        }
