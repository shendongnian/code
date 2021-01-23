    private string _ModelName;
        public string ModelName
        {
            get { return _ModelName; }
            set
            {
                if (_ModelName != value)
                {
                    _ModelName = value;
                    RaisePropertyChanged("ModelName");
                }
            }
        }
		
