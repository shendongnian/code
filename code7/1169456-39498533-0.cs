	public class BoolToBorderBrushConverter : IValueConverter
	{
		public SolidColorBrush TrueColor { get; set; }
		public SolidColorBrush FalseColor { get; set; }
		// this example compares a binding property (string) with 1 parameter (also in string)
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null && parameter != null)
			{
				if (String.Compare(value.ToString(), parameter.ToString(), true) == 0)
				{
					return this.TrueColor;
				}
				else
				{
					return this.FalseColor;
				}
			}
			return this.FalseColor;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
