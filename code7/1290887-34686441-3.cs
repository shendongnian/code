    public class MarginConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			string[] positions = parameter.ToString().Split(',');
			double leftPos = double.Parse(positions[0]);
			double topPos = double.Parse(positions[1]);
			double rightPos = double.Parse(positions[2]);
			double bottomPos = double.Parse(positions[3]);
			var actualMargin = new Thickness(leftPos, topPos, rightPos, bottomPos);
			return new Thickness(actualMargin.Left * (double)values[0],
								 actualMargin.Top * (double)values[1],
								 actualMargin.Right * (double)values[0],
								 actualMargin.Bottom * (double)values[1]);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
