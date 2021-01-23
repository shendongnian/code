    public class MultiBindingMultiplier : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length > 1)
            {
                try
                {
                    double value = (double)values[0];
                    for (int i = 1; i < values.Length; i++)
                    {
                        value *= (double)values[i];
                    }
                    return value;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
