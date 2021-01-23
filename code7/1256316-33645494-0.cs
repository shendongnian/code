    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
    	if ((bool)value)
    	{
    		string parameterString = parameter as string;
    		if (parameterString == null)
    			return DependencyProperty.UnsetValue;
    
    		return Enum.Parse(targetType, parameterString);
    	}
    	else
    		return DependencyProperty.UnsetValue;
    }
