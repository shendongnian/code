        private CustomTable _child;
        public CustomTable Child
        {
            get
            {
                return _child;
            }
            set
            {
                _child = value;
                OnPropertyChanged("Child");
            }
        }
