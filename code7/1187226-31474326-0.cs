	public class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var b = value as bool?;
			return b.GetValueOrDefault() ?  Visibility.Visible : Visibility.Collapsed ;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            if (!(value is Visibility)) return false;
            var b = (Visibility)value;
            return b == Visibility.Visible ? true : false ;
        }
    }
	
