        //private string _firstValue;
        public string FirstValue
        {
            get { return cc.FirstValue; }
            set
            {
                //_firstValue = value;
                cc.FirstValue = value;           // add this
                OnPropertyChanged("FirstValue");
            }
        }
