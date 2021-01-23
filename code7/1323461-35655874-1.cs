    private SolidColorBrush buttonColor;
    public SolidColorBrush ButtonColor
    {
        get { return buttonColor; }
        set
        {
            buttonColor = value;
            NotifyPropertyChanged("ButtonColor");
        }
    }
