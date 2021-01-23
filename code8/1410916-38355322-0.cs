    public BitmapImage Original
    {
        get { return _original; }
        set
        {
            _original = value;
            base.RaisePropertyChanged();
        }
    }
    ...
    
     Original = OriginalBitmap;
