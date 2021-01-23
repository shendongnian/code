    public class BooleanToIntegerConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if ((bool)value)
                    return 1;
                else
                    return 0;
            }
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            { throw new NotImplementedException(); }
        }
