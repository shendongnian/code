    public class AlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
                return Windows.UI.Xaml.HorizontalAlignment.Center;
            return Windows.UI.Xaml.HorizontalAlignment.Left;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
