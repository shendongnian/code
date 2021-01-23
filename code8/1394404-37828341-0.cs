            private string _TimeZome;
            public string TimeZome
            {
                get { return _TimeZome; }
                set
                {
                    if (value == _TimeZome)
                        return;
    
                    _TimeZome = value;
                    this.OnPropertyChanged("TimeZome");
                }
            }
