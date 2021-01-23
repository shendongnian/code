    public class DobToColorConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if (value is DateTime)
    		{
    			var brush = new SolidColorBrush(Colors.Transparent);
    
    			var dob = (DateTime)value;
    			
    			if (dob.Year <= 2000)
    			{
    				brush.Color = Colors.LightGray;
    			}
    
    			return brush;
    		}
    
    		return null;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
