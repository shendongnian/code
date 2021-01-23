    public class Converter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, string language)
       {
          return (bool)value ? new BitmapImage(new Uri("trueImagePath")) : new BitmapImage(new Uri("falseImagePath"));
       }
    
       public object ConvertBack(object value, Type targetType, object parameter, string language)
       {
          throw new NotImplementedException();
       }
    }
