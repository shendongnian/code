    public class Class
    {
        private Dictionary<string, string> _dictionary;
    
        public Class()
        {
            _dictionary = new Dictionary<string, string>()
            {
                { "First", "Foo" },
                { "Second", "Bar" }
            };
        }
    
        public string this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }
    }
