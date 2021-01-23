    class SearchCriteria
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value == null ? null : value.Trim(); }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value == null ? null : value.Trim(); }
        }
        private string _Company;
        public string Company
        {
            get { return _Company; }
            set { _Company = value == null ? null : value.Trim(); }
        }
        // ... around 20 fields follow
    }
