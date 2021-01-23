    /// <summary>
    /// Take the current state, passed in as value which is bound, and check it against
    /// the parameter passed in. If the names match, the ellipse should be visible,
    /// if not equal, then it should be collapsed.
    /// </summary>
    public class OperationStateToVisiblity : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null)     && 
                    (parameter != null) &&
                    value.ToString().Equals(parameter.ToString())
                ? Visibility.Visible : Visibility.Collapsed;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
