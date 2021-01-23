    private Brush buttonColor;
    public Brush ButtonColor
    {
        get { return buttonColor; }
        set
        {
            buttonColor = value;
            NotifyPropertyChanged("ButtonColor");
        }
    }
