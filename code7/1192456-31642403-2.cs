    public class MultiDictionaryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is string && values[1] is Dictionary<string, bool>)
            {/*
                ((Dictionary<string, bool>)values[1])[values[0] as string] =
                    !((Dictionary<string, bool>)values[1])[values[0] as string];*/
                return ((Dictionary<string, bool>)values[1])[values[0] as string];
            }
            return false;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
