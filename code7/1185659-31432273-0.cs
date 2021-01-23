    public interface IValueConverter<T> : IValueConverter
    {
        object Convert(T value, Type targetType, object parameter, CultureInfo culture);
        object ConvertBack(T value, Type targetType, object parameter, CultureInfo culture);
    }
    public abstract class GenericConverter<T> : IValueConverter<T>
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckType(value);
            return Convert((T)value, targetType, parameter, culture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckType(value);
            return ConvertBack((T)value, targetType, parameter, culture);
        }
        private void CheckType(object value)
        {
            if (value == null)
            {
                //TODO: Do something about nulls.
            }
            Type type = typeof(T);
            if (value.GetType() != type)
                throw new InvalidCastException(string.Format("Converter value could not be cast to: ", type.Name));
        }
        public abstract object Convert(T value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(T value, Type targetType, object parameter, CultureInfo culture);
    }
