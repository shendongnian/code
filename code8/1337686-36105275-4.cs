    public static event PropertyChangedEventHandler PropertyChanged;
    private static void OnPropertyChanged (string propertyName)
    {
        var changed = PropertyChanged;
        if (changed != null) 
        {
            PropertyChanged (this, new PropertyChangedEventArgs    (propertyName));    
        }
    }
    private static int _value1;
    public static int value1
    {
        get { return _value1; }
        set 
        { 
            _value1 = value;
            OnPropertyChanged("value1");
        } 
    }
