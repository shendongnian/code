    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
    	if ((bool)value)
    		return System.Windows.Media.Brushes.White;
    	else
    		return System.Windows.Media.Brushes.WhiteSmoke;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
    	throw new NotImplementedException("One way conversions only!");
    }
