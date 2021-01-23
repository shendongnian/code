    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // if you want to handle `double` too you can uncomment following lines but this is an ugly hack
            // if (value != null && value.GetType() == typeof(double))
            // {
            //    return value;
            // }
            var nullableDouble = (double?)value;
            if (nullableDouble.HasValue)
            {
                return nullableDouble.Value;
            }
            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
