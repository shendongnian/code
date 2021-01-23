    class SearchCriteria
    {
        private Dictionary<string, string> _internalValues = new Dictionary<string, string>();
        public string Name { get { return _internalValues.ContainsKey("Name") ? _internalValues["Name"] : null; } set { _internalValues["Name"] = value; } }
        ....
    
        public void Trim()
        {
            foreach (var entry in _internalValues)
            {
                if (!string.IsNullOrEmpty(entry.Value)) entry.Value = entry.Value.Trim();
            }
        }
    }
