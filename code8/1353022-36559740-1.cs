	class HasClaimConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var name= values[0] as String;
			var vm = values[1] as YourViewModel;
			return YourViewModel.HasClaim(name);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
