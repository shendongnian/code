       private Country _selectedCountry;
        public Country SelectedCountry
        {
            get
            {
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                _selectedRow.countryCode = _selectedCountry.code;
                OnPropertyChanged("SelectedRow");
              
            }
        }
        private Record _selectedRow;
        public Record SelectedRow
        {
            get {
                return _selectedRow;
                
            }
            set
            {
                _selectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
            
            
        }
