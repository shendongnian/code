    [ValueConversion(typeof(SexEnum), typeof(Brush))]
    public class SexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is SexEnum))
                throw new ArgumentException("value not of type StateValue");
            SexEnum sv = (SexEnum)value;
            //sanity checks
            if (sv == SexEnum.Female)
                return Brushes.Red;
            return Brushes.Blue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
