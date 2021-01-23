    private Color pvColor = Colors.Green;
    private Color fgColor
    {
        get { return pvColor; }
        set
        {
            pvColor = value;
            this.OnPropertyChanged("fgColor"); // Make sure you have INotifyPropertyChanged implemented
        }
    }
