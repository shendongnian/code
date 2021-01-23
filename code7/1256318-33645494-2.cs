    public class EnumToBooleanConverter : IValueConverter
    {
    	public object Convert(
    		object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		return (TestEnum)value == (TestEnum)parameter;
    	}
    
    	public object ConvertBack(
    		object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		if ((bool)value)
    			return parameter;
    		else
    			return DependencyProperty.UnsetValue;
    	}
    }
