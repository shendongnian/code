    public class MyRegistry
    {
        Dictionary<string, string> _items = new Dictionary<string,string>();
    
        public string this[string name]
        {
            get { return _items[name]; }
        }
    }
