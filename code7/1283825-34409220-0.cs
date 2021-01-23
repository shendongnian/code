        internal class ListToString : IValueConverter
        {
          
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is List<string>)
                {
                    return string.Join(", ", value);
                }
    
                return null;
            }  
           
          
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
