    public class MultiStringToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
                      System.Globalization.CultureInfo culture)
        {
            var item = values[0] as string;
            var current = values[1] as string;
    
            if (item == current)
                return new SolidColorBrush(Colors.Green);
            return new SolidColorBrush(Colors.White);
        }
    
        public object[] ConvertBack(object values, Type[] targetType, object parameter,
                        System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
