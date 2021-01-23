    public static event PropertyChangedEventHandler StaticPropertyChanged;
    private static void OnStaticPropertyChanged(string propertyName)
    {
        var handler = StaticPropertyChanged;
        if (handler != null)
        {
            handler(null, new PropertyChangedEventArgs(propertyName));
        }
    }
