    class ItemTypeToBoldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string text = value as string;
            if (text != null)
            {
                return text == "Module" ?
                    Windows.UI.Text.FontWeights.Bold :
                    Windows.UI.Text.FontWeights.Normal;
            }
            return Windows.UI.Xaml.DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    class ItemTypeToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string text = value as string;
            if (text != null)
            {
                return text == "Unit" ?
                    new Windows.UI.Xaml.Thickness(20, 0, 0, 0) :
                    new Windows.UI.Xaml.Thickness();
            }
            return Windows.UI.Xaml.DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
