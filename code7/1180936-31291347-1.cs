	class SbyteToBoolConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value if sbyte)
				return ConvertSbyteToBool((sbyte)value);
			else
				return ConvertBoolToSbyte((bool)value);
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
				return ConvertBoolToSbyte((bool)value);
			else
				return ConvertSbyteToBool((sbyte)value);
		}
		
		...
	}
