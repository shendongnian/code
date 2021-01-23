    public class RegistryFuncs
    {
        public static List<Key> GetSubkeysValue(string path, RegistryHive hive)
        {
            var result = new List<Key>();
            using (var hiveKey = RegistryKey.OpenBaseKey(hive, RegistryView.Default))
            using (var key = hiveKey.OpenSubKey(path))
            {
                var subkeys = key.GetSubKeyNames();
                foreach (var subkey in subkeys)
                {
                    var values = GetKeyValue(hiveKey, path, subkey);
                    result.Add(values);
                }
            }
            return result;
        }
        public static Key GetKeyValue(RegistryKey hive, string path, string keyName)
        {
            var result = new Key() { KeyName = keyName };
            var subkey = $@"{path}\{keyName}";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey))
            {
                if (key == null) return null;
                
                foreach (var valueName in key.GetValueNames())
                {
                    var val = key.GetValue(valueName);
                    var pair = new KeyValuePair<string, object>(valueName, val);
                    result.Values.Add(pair);
                }
            }
            return result;
        }
    }
    public class Key
    {
        public string KeyName { get; set; }
        public List<KeyValuePair<string, object>> Values { get; set; }
        public Key()
        {
            Values = new List<KeyValuePair<string, object>>();
        }
    }
