    public class ThicknessToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Thickness thikness = (Thickness)value;
            return $"{thikness.Left},{thikness.Top},{thikness.Right},{thikness.Bottom}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Because you are not using a view/view model, validation should go here!
            string[] thicknessValues = ((string)value).Split(',');
            return new Thickness(double.Parse(thicknessValues[0]),
                double.Parse(thicknessValues[1]),
                double.Parse(thicknessValues[2]),
                double.Parse(thicknessValues[3]));
        }
    }
