     public class MyProgressBarWidthConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if (values.Any(c => c == null || c == DependencyProperty.UnsetValue))
                return 0.0d;
            var min = (double) values[0];
            var current = (double) values[1];
            var max = (double) values[2];
            const double maxWidth = 475; // that is from template
            return (current/(max - min))*maxWidth;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
