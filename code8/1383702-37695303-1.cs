    public class CmToPixelConverter : IValueConverter
    {
        double ratio = DisplayHelper.GetCmToPixelRatio();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * ratio;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
