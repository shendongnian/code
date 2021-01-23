    private PropertyChangedEventHandler PropertyChanged;
    public event PropertyChangedEventHandler PropertyChanged
    {
        add { PropertyChanged += value; }
        remove { PropertyChanged -= value; }
    }
