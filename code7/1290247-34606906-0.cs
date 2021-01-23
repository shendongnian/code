    Cursor={Binding Source,Converter={StaticResources CursorConverter}
    
     public class CursorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (!string.IsNullorEmpty(value.Tostring()))
                {
                    return Cursor.Hand;
                }
                else
                {
                    return Cursor.Arrow;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
