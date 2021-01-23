    private Color pvColor = Colors.Green;
    public Color fgColor
    {
        get { return pvColor; }
        set
        {
            pvColor = value;
            this.OnPropertyChanged("fgColor"); // Make sure you have INotifyPropertyChanged implemented
        }
    }
