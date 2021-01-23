    public class KeyValueSet //this dictionary item is tailor made for this example
    {
        public string KeyStr { get; set; }
        public int KeyInt { get; set; }
        public int Value { get; set; }
        public KeyValueSet() { }
        public KeyValueSet(string keyStr, int keyInt, int value)
        {
            KeyStr = keyStr;
            KeyInt = keyInt;
            Value = value;
        }
    }
    public class DoubleKeyDictionary
    {
        List<KeyValueSet> _list = new List<KeyValueSet>();
        public void Add(KeyValueSet set)
        {
            if (set == null)
                throw new InvalidOperationException("Cannot add null");
            if (string.IsNullOrEmpty(set.KeyStr) && set.KeyInt == 0)
                throw new InvalidOperationException("Invalid key");
            if (!string.IsNullOrEmpty(set.KeyStr) && _list.Any(l => l.KeyStr.Equals(set.KeyStr))
                || set.KeyInt != 0 && _list.Any(l => l.KeyInt == set.KeyInt))
                throw new InvalidOperationException("Either of keys exists");
            _list.Add(set);
        }
        public void Add(string key, int value)
        {
            Add(new KeyValueSet { KeyInt = 0, KeyStr = key, Value = value });
        }
        public void Add(int key, int value)
        {
            Add(new KeyValueSet { KeyInt = key, KeyStr = string.Empty, Value = value });
        }
        public void Remove(int key)
        {
            if (key == 0)
                throw new InvalidDataException("Key not found");
            var val = _list.First(l => l.KeyInt == key);
            _list.Remove(val);
        }
        public void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new InvalidDataException("Key not found");
            var val = _list.First(l => l.KeyStr == key);
            _list.Remove(val);
        }
        public void Remove(KeyValueSet item)
        {
            _list.Remove(item);
        }
        public int this[int index]
        {
            get
            {
                if (index != 0 && _list.Any(l => l.KeyInt == index))
                    return _list.First(l => l.KeyInt == index).Value;
                throw new InvalidDataException("Key not found");
            }
            set
            {
                Add(index, value);
            }
        }
        public int this[string key]
        {
            get
            {
                if (!string.IsNullOrEmpty(key) && _list.Any(l => l.KeyStr == key))
                    return _list.First(l => l.KeyStr == key).Value;
                throw new InvalidDataException("Key not found");
            }
            set
            {
                Add(key, value);
            }
        }
    }
