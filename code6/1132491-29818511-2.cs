    class SearchCriteria
    {    
        private string Trim(string field)
        {
            if( ! String.IsNullOrEmpty( field ) )
                field = field.Trim();
            return field;
        }
    
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = Trim(value); }
        }
    
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = Trim(value); }
    
        }
       
        // ... other string properties
        // no public void Trim() method
    }
