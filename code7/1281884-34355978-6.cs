    public class DateToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        CustomTask t = (CustomTask)value;
        if(t == null)
			return null;	// or other default value
        ...
    }
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
