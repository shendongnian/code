       public ObservableCollection<Person> Persons
        {
            get { return _observableprsn; }
            set
            {
                if (_observableprsn != value)
                {
                    _observableprsn = value;
                }
            }
        }
        private ObservableCollection<Person> _observableprsn { get; set; }
    
