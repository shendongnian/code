    public object Convert(object value, Type targetType, object parameter,
                          System.Globalization.CultureInfo culture)
    {
        return System.Convert.ToBoolean(value);
    }
    public object ConvertBack(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
    {
        return Enum.ToObject(targetType, value);
    }
