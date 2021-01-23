    public class ComboBoxItemConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value as MainPage.ComboBoxItem;
        }
    }
