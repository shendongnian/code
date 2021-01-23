    public sealed class DecimalConverter : IValueConverter
    {
    	public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
    	{
    		double result = 0;
    		if ( value is double )
    			result = Math.Round( ( double )value, 2 );
    		return result;
    	}
    
    	public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
    	{
    		throw new NotImplementedException();
    	}
    }
