    public class Locale
    {
        Dictionary<string, string> _dict;
        public Locale()
        {
            _dict = new Dictionary<string, string>();
            _dict.Add("dot", "net");
            _dict.Add("java", "script");
        }
        public string this[string key] //this is the indexer
        {
            get
            {
                return _dict[key];
            }
            set //remove setter if you do not need
            {
                _dict[key] = value;
            }
        }
    }
