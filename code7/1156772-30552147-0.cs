    private bool _newCall;
        public bool newCall
        {
            get { return _newCall; }
            set
            { 
                _newCall = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("newCall"));
                }
            }
        }
