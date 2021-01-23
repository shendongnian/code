    public bool Checked {
        get
        {
            return _checked;
        }
        set
        {
            _checked = value;
            OnPropertyChanged("Checked");
        }
     }    
