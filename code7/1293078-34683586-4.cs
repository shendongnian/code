    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var vm = value as MyViewModel;
        var type = (String)parameter;
        return new List<String>
        {
            "Test1" + type,
            "Test2" + type
        };
    }
