    public class NullableValueConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                throw new ArgumentNullException(nameof(value));
            }
            return value;
        }
        // ...
    }
