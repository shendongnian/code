        private string _ticker;
        public string Ticker
        {
            get { return _ticker; }
            set
            {
                if (value != _ticker)
                {
                    _ticker = value;
                    OnPropertyChanged("Ticker");
                    OnPropertyChanged("PostBack");
                }
            }
        }
