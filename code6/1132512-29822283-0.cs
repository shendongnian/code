    class SearchCriteria
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; }}
        public string Email { get; set; }
        public string Company { get; set; }
        // ... around 20 fields follow
        void Trim(ref string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                str = str.Trim();
            }
        }
        public void Trim()
        {
            Trim(ref _name);
            // ... repeat for all 20 fields in the class.
        }
    }
