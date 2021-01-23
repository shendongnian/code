    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var width = (double)value;
            double itemmargin = width / 6;
            Thickness margin = new Thickness(itemmargin, 0, itemmargin, 0);
            return margin;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
