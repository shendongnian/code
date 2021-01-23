    public string FontColor
    {
        get
        {
            return _fontColor;
        }
        set
        {
            _fontColor = value;
            //note it fires two changed events!
            OnPropertyChanged("ForegroundColorToDisplay");
            OnPropertyChanged("FontColor");
        }
    }
    
    public Brush ForegroundColorToDisplay
    {
        get
        {
            return GetBrushFromColorString(value);;
        }
    }
