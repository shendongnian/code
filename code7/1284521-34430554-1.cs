    public class TextBlockVisibilityConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if((value[0] != null && (bool)value[0]) || (value[1]!=null && !String.IsNullOrEmpty(value[1].ToString())))
            {
                return Visibility.Visible;
            }    
            return Visibility.Collapsed;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
