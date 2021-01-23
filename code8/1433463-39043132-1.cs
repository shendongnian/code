    /// <summary>
    /// Converter which expects two params. percentage and maximum height
    /// </summary>
    public class LiquidLevelConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var percentage = (int) values[0];
            var maxHeight = (double) values[1];
            return percentage*maxHeight*0.01;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
