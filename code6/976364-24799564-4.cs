    public class PointArrayToPointCollection : IValueConverter {
       object IValueConverter.Convert(object value, Type targetType, 
                                      object parameter, CultureInfo culture) {
          var points = value as IEnumerable<Point>;
          if(points != null) return new PointCollection(points);
          return Binding.DoNothing;
       }
       object IValueConverter.ConvertBack(object value, Type targetType,
                                          object parameter, CultureInfo culture) {
          throw new NotImplementedException();
       }
    }
