    public class PropertySelectorConverter : IMultiValueConverter
    {    
        public object Convert(object[] values, Type targetType, object parameter, string language)
        {
            var properties = (Tuple<double, double>)values[0];
            bool propertySelector = (bool)values[1];
            return propertySelector ? properties.Item1 : properties.Item2;
        }
    
        public object ConvertBack(object[] values, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
