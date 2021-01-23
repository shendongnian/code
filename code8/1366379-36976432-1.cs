     public class BooleanToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                var boolValue = System.Convert.ToBoolean(value);
    
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                return ((Visibility)value == Visibility.Visible) ? true : false;
                ;
            }
        }
  
