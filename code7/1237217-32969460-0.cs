    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
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
