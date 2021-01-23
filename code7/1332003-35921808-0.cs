    public class ColorConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return (SolidColorBrush)(new BrushConverter().ConvertFrom((string)value));	
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return null;
    	}
    }
