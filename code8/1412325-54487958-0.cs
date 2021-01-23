    public class BooleanOrConverter : IMultiValueConverter {
       public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
          return values.Cast<bool>().Any();
       }
       public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
          throw new NotImplementedException();
       }
    }
