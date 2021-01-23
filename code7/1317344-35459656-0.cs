    public string Text
    { 
        get { return _text; }
        set
        {
            _text = value;
            NotifyPropertyChanged("Text");
        }
