	public class SelectorToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)    
		{
			var selector = (int)value;
			var desired = (int)parameter; //may need a string to int conversion
			
			return selector == desired ? Visibility.Visible : Visibility.Collapsed;
		}
	}
