    public class MyNewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Perform all required conversions here and return them as a new type of object
            return new
                {
                    Data = ...,
                    Fill = ...,
                    Stroke = ...
                };
        }
    }
