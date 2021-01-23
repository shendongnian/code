    public class SelectedLegendItemToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var isSelected = (bool) value;
            return isSelected
                ? Application.Current.Resources["SystemControlForegroundBaseMediumBrush"] as Brush
                : Application.Current.Resources["SystemControlForegroundListMediumBrush"] as Brush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
