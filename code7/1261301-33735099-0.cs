    public class EnumerableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (targetType.IsInstanceOfType(value))
                return value;
            if (value.GetType().GetInterfaces().Contains(typeof(IEnumerable)) && targetType.IsGenericType
                && !targetType.IsGenericTypeDefinition && targetType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return ((IEnumerable)value).Cast(targetType.GetGenericArguments().Single());
            throw new InvalidOperationException(
                string.Format("Can't convert from {0} to {1}", value.GetType(), targetType));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
