    <yourNameSpace:ColorToSolidColorBrushConverter x:Key="ColorToSolidColorBrushConverter" />
	<SolidColorBrush x:Key="FGColor" Color="{Binding Path=pvColor, Converter={StaticResource ColorToSolidColorBrushConverter}}"/>
	
	public class ColorToSolidColorBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Color desiredColor = value as Color;
			if(desiredColor != null)
			{
				return new SolidColorBrush(desiredColor);
			}
		 
			//Return here your default
			return DependencyProperty.UnsetValue;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DependencyProperty.UnsetValue;
		}
	}
