    public class Converter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        if ((bool)value) return Brushes.Red;
        return null;
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        new throw Exception();
      }
    }
