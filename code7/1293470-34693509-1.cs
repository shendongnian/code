    public class MyConverter
            : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string myValue = value as string;
                int result = 0;
                if (myValue != null)
                {
                    int.TryParse(myValue,out result);
                }
    
                return result > 0;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                // not relevant for your application
                throw new NotImplementedException();
            }
        }
