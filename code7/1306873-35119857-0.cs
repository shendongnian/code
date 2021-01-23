    public class EllipseColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool btn1 = (bool)values[0];
            bool btn2 = (bool)values[1];
            if (btn1 && !btn2)
                return Brushes.Red;
            else if (btn2 && !btn1)
                return Brushes.Blue;
            else if (btn1 && btn2)
                return Brushes.Pink;
            else
                return Brushes.Black;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
