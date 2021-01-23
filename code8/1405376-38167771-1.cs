    public class HeightToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double ContainerHeight = (double)values[0];
            double StockGridHeight = (double)values[1];
            if (ContainerHeight < StockGridHeight)
                return Visibility.Hidden;
            else
                return Visibility.Visible;
       }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
