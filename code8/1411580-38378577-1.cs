    public class IsCurrentZoomFactor : MarkupExtension, IValueConverter
    {
        public int DesiredZoomFactor { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int currentZoomFactor = (int)value;
            return DesiredZoomFactor == currentZoomFactor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
