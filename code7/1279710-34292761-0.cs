    public class AddHeightConverter : System.Windows.Data.IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (double)value + 5.0;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return System.Windows.Data.Binding.DoNothing;
		}
	}
