    public static SolidColorBrush property = Brushes.Red; // backing field
    public static SolidColorBrush Property
    {
        get { return property; }
        set
        {
            property = value;
            OnStaticPropertyChanged("Property");
        }
    }
