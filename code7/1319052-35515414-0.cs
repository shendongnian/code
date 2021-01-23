    public class TestClass
    {
        private Dictionary<string, int> _testDictionary = new Dictionary<string, int>();
    
        // you do not need a private property to store the key
        // private string _key;
    
        [IndexerName("MyKeyItem")]
        public int this[string key]
        {
            get
            {
                if (_testDictionary.ContainsKey(key))
                {
                    return _testDictionary[key];
                }
    
                return int.MinValue;
            }
    
            set
            {
                if (_testDictionary.ContainsKey(key))
                    _testDictionary[key] = value;
                else
                    _testDictionary.Add(key, value);
            }
        }
    }
