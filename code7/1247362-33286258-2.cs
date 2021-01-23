    public class MarkToPassedConverter : IValueConverter {
       public object Convert(object value, Type targetType, object parameter, 
                             CultureInfo culture){
           var mark = (int) value;
           return mark >= 50;
       }
       public object ConvertBack(object value, Type targetType, object parameter, 
                                 CultureInfo culture){
           throw new NotImplementedException();
       }
    }
