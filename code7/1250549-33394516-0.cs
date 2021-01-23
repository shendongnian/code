    public class ItemToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int? itemCount = value as int?;
                if (itemCount < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch { return DependencyProperty.UnsetValue; }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }  
