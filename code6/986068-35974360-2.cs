        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if ((value!= null && value.length <= 5) || value == null)
                {
                    _name = value;
                }
                OnPropertyChanged();
            }
