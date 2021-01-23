    public class Properties
    {
        private IDictionary<string, string> _extendedProperties;
        public IDictionary<string, string> ExtendedProperties
        {
            get
            {
                return
                    _extendedProperties == null ?
                        new Dictionary<string, string>() { { "Name", "" }, { "Number", "" }, { "Age", "" } } :
                        _extendedProperties;
            }
            set 
            { 
                _extendedProperties = value; 
                //here you can also check if value misses those key to add them to _extendedProperties
            }
        }
    }
