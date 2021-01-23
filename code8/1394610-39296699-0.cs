    public class NoElementVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            ObservableCollection<int> ienum = value as ObservableCollection<int>;
            return ienum == null || ienum.Count() == 0 ? Visibility.Collapsed : Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
                _converter = new NoElementVisibilityConverter();
            return _converter;
        }
        private static NoElementVisibilityConverter _converter = null;
    }
