    public class ParameterizedString
    {
        private string _BaseString;
        private Dictionary<string, string> _Parameters;
        public ParameterizedString(string baseString)
        {
            _BaseString = baseString;
            _Parameters = new Dictionary<string, string>();
        }
        public bool AddParameter(string name, string value)
        {
            if(_Parameters.ContainsKey(name))
            {
                return false;
            }
            _Parameters.Add(name, value);
            return true;
        }
        public override string ToString()
        {
            var sb = new StringBuilder(_BaseString);
            foreach (var key in _Parameters.Keys)
            {
                sb.Replace(key, _Parameters[key]);
            }
            return sb.ToString();
        }
    }
