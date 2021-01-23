    public class MovementToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var movement = value as Movement;
			if (movement == PriceMovement.Up)
				return Brushes.Green;
			//return values for the other cases accordingly
			return Brushes.Transparent; //default
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
