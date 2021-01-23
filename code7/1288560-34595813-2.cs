	public class ArrayConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var array = value as int[];
			if (array != null)
			{
				return "{" + String.Join(",", array) + "}";
			}
			return value;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
 
