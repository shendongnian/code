    public enum TextFilterType
    {
        StartsWith,
        EndsWith,
        Contains,
        ExactMatch
    }
    public class StringQuery
    {
        private readonly string _value;
        private readonly TextFilterType _filterType;
        public StringQuery(string value, TextFilterType filterType)
        {
            _value = value;
            _filterType = filterType;
        } 
        public string Value
        {
            get { return _value; }
        }
        public TextFilterType FilterType
        {
            get { return _filterType; }
        }
    }
