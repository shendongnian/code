    [FieldIgnored]
    private PropertyChangedEventHandler PropertyChangedField;
    public event PropertyChangedEventHandler PropertyChanged
    {
        add { PropertyChanged += value; }
        remove { PropertyChanged -= value; }
    }
