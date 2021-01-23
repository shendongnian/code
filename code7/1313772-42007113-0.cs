    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    public class BooleanToColorConverter : IValueConverter
    {
        public Brush TrueBrush { get; set; }
        public Brush FalseBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = value as bool? ?? true;
            if (parameter != null && parameter.ToString() == "!")
            {
                boolValue = !boolValue;
            }
            if (boolValue)
            {
                return TrueBrush;
            }
            return FalseBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
