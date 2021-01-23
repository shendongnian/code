    public class ResouceLookupConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            return App.Current.TryFindResource(value);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, 
                                  System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
