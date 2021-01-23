    public class ObjectToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                             CultureInfo culture)
        {
            bool returnValue = true;
            if (value == DependencyProperty.UnsetValue || value == null)
            {
                returnValue = false;
            }
            return returnValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                                  CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
