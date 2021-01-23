    [ValueConversion(typeof(bool?), typeof(string))]
    public sealed class NullableBoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return ThreeStateComboBoxItemsSource.None;
            return (bool)value ? ThreeStateComboBoxItemsSource.Yes : ThreeStateComboBoxItemsSource.No;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((string)value)
            {
                case ThreeStateComboBoxItemsSource.Yes:
                    return true;
                case ThreeStateComboBoxItemsSource.No:
                    return false;
                default:
                    return null;
            }
        }
    }
