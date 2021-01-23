    public class DebugTypeCheck : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
        	return this;
        }
    	
    	public Type CheckType { get; set; }
    
        [Conditional("DEBUG")]
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           	if (value.GetType() != CheckType)
           	{
            	throw new ArgumentException(); // developer error
           	}
            		
    		return value;
        }  
    	
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           	throw new NotImplementedException();
        } 
    }
    
    public class DebugTypeCheckConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           	if (value.GetType() != (Type)parameter)
           	{
            	throw new ArgumentException(); // developer error
           	}
            		
    		return value;
        }  
    	
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           	throw new NotImplementedException();
        } 
    }
