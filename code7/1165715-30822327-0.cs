    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? "D:\\Test\\Test\\bin\\Debug\\img\\add.png" : "D:\\Test\\Test\\bin\\Debug\\img\\minus.png";
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false; // not needed
        }
    }
