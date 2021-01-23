	class SbyteToBoolConverter: IValueConverter
	{
		public bool UseOppositeDirection { get; set; }
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (UseOppositeDirection)
				return ConvertSbyteToBool((sbyte)value);
			else
				return ConvertBoolToSbyte((bool)value);
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (UseOppositeDirection)
				return ConvertBoolToSbyte((bool)value);
			else
				return ConvertSbyteToBool((sbyte)value);
		}
		
		public sbyte ConvertBoolToSbyte(bool input)
		{
			if (input)
				return 1;
			else
				return 0;
		}
		
		public bool ConvertSbyteToBool(sbyte input)
		{
			if (input == 0)
				return false;
			else
				return true;
		}
	}
