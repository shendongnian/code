    public class MyClass
    {
        Dictionary<string, IReadOnlyList<string>> _dictionary;
        public IReadOnlyDictionary<string, IReadOnlyList<string>> Dictionary { get { return _dictionary; } }
        public MyClass()
        {
            _dictionary = new Dictionary<string, IReadOnlyList<string>>();
        }
        public void AddItem(string item)
        {
            IReadOnlyList<string> readOnlyList = null;
            List<string> list = null;
            if (!_dictionary.TryGetValue(item, out readOnlyList))
            {
                list = new List<string>();
                _dictionary.Add(item, list);
            }
            else
                list = readOnlyList as List<string>;
            list.Add(item);
        }
    }
