        class Key
        {
            public string KeyName { get; set; }
            public List<KeyValuePair<string, object>> Values { get; set; }
        }
        private List<Key> GetSubkeysValue(string path, RegistryHive hive)
        {
            var result = new List<Key>();
            using (var hiveKey = RegistryKey.OpenBaseKey(hive, RegistryView.Default))
            using (var key = hiveKey.OpenSubKey(path))
            {
                var subkeys = key.GetSubKeyNames();
                foreach (var subkey in subkeys)
                {
                    var values = GetKeyValue(hiveKey, subkey);
                    result.Add(values);
                }
            }
            return result;
        }
        private Key GetKeyValue(RegistryKey hive, string keyName)
        {
            var result = new Key() {KeyName = keyName};
            using (var key = hive.OpenSubKey(keyName))
            {
                foreach (var valueName in key.GetValueNames())
                {
                    var val = key.GetValue(valueName);
                    var pair = new KeyValuePair<string, object>(valueName, val);
                    result.Values.Add(pair);
                }
            }
            return result;
        }
