    public class ItemWithIndexer
    {
        private readonly Dictionary<string, string> _dictionary = 
            new Dictionary<string, string>();
    
        public string this[string index]
        {
            get { return _dictionary[index]; }
            set { _dictionary[index] = value; }
        }
    }
