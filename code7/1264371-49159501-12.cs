	public class InlineMultiConverter : IMultiValueConverter {
		public delegate object   ConvertDelegate    (object[] values, Type   targetType,  object parameter, CultureInfo culture);
		public delegate object[] ConvertBackDelegate(object   value,  Type[] targetTypes, object parameter, CultureInfo culture);
		public InlineMultiConverter(ConvertDelegate convert, ConvertBackDelegate convertBack = null){
			_convert     = convert ?? throw new ArgumentNullException(nameof(convert));
			_convertBack = convertBack;
		}
		private ConvertDelegate     _convert     { get; }
		private ConvertBackDelegate _convertBack { get; }
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
			=> _convert(values, targetType, parameter, culture);
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
			=> (_convertBack != null)
				? _convertBack(value, targetTypes, parameter, culture)
				: throw new NotImplementedException();
	}
