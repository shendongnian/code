    public int Selected
            {
                get { return _selected; }
    
                set
                {
                    _selected = value;
    
                    OnPropertyChanged(new PropertyChangedEventArgs("Selected"));
                }
            }
    
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
