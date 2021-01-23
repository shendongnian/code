    public class StringFormatExtension : MarkupExtension, IMultiValueConverter
    {
    	public string FormatString { get; set; }
    
    	public StringFormatExtension(string formatString)
    	{
    		if (formatString == null) throw new ArgumentNullException("formatString");
    		FormatString = formatString;
    	}
    
    	public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return String.Format(FormatString, values);
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    	{
    		throw new NotSupportedException();
    	}
    
    	public override object ProvideValue(IServiceProvider serviceProvider)
    	{
    		return this;
    	}
    }
