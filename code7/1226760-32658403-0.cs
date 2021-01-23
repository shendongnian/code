    public class TwoWayDictionary //Should probably specify generic types
    {
        private Dictionary<string, string> _first;
        private Dictionary<string, string> _second;
        public TwoWayDictionary()
        {
            _first = new Dictionary<string, string>();
            _second = new Dictionary<string, string>();
        }
        public void Add(string first, string second)
        {
            _first.Add(first, second);
            _second.Add(second, first);
        }
    
        public string this[string value]
        {
            get
            {
                if(_first.Contains(value))
                {
                    return _first[value];
                }
                if(_second.Contains(value))
                {
                    return _second[value];
                }
            
                return null; //Or throw arg exception or whatever
            }
        }
    }
