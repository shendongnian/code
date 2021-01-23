    public sealed class PercentageOfValueConverter : IValueConverter
    {
        private const double DefaultValue = 150;
        private const double Percentage = 0.9;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double result = 0;
            double.TryParse(value.ToString(), out result);
            if (result == double.NaN)
            {
                return DefaultValue; // Default value.
            }
            // Thickness gets assigned to the Padding property.
            return new Thickness(result * Percentage, 0, result * Percentage, 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
