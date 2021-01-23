    public class ItemsCountToColCountConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        return (int)Math.Ceiling((int)value / 5f);
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
    public class FiveRowToRowNumberConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        return ((int)value - 1) % 5f;
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
    public class FiveRowToColNumberConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        return (int)Math.Floor(((int)value - 1) / 5f);
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
