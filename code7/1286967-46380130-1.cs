    class TabSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            TabControl tabCtrl = values[0] as TabControl;
            double width = tabCtrl.ActualWidth / tabCtrl.Items.Count;
            return width <= 1 ? 0 : width - 1;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
