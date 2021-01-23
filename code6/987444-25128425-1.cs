        private string _firstValue;
        public string FirstValue
        {
            get { return _firstValue; }
            set
            {
                _firstValue = value;
                cc.FirstValue = _firstValue;     // add this
                OnPropertyChanged("FirstValue");
            }
        }
