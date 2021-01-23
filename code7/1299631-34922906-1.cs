    public class ExpanderHeaderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string output = string.Empty;
            for (int i = 0; i < values.Length; i+=2)
            {
                if ((values[i + 1] as bool?) == true)
                    output += (values[i] as CheckBox).Content.ToString()+" ";
            }
            return output;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
