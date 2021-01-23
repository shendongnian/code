    public class MyEnumToStringConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return value.ToString();
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return (TheEnum)Enum.Parse(typeof(TheEnum), value.ToString(), true);
    	}
    }
