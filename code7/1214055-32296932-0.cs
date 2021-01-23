    public class NameToBrushMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string name = (string)values[0];
            string firstName = (string) values[1];
            if (name.Equals(firstName))
                return Brushes.Red;
            
            return Brushes.Transparent;
        }
        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
