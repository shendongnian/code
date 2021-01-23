    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SomeThirdPartyClassStatus)value == SomeThirdPartyClassStatus.Status1;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool?)value == true ? SomeThirdPartyClassStatus.Status1 : SomeThirdPartyClassStatus.Status2;
        }
    }
