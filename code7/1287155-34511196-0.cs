    /// <summary>
    /// The actual implementation of InverseBooleanVisibilityConverter
    /// </summary>
    internal class RangeConverter : IValueConverter
    {
        /// <summary>
        /// Converters the Boolean value to Visibility inversely
        /// </summary>
        /// <param name="value">The Boolean value</param>
        /// <param name="targetType">The target value</param>
        /// <param name="parameter">The parameter</param>
        /// <param name="culture">The culture of the value</param>
        /// <returns>Returns the a Visibility Type Value</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int j;
            Int32.TryParse(value as string, out j);
            if (j <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        /// <summary>
        /// Converters the Visibility value to Boolean inversely
        /// </summary>
        /// <param name="value">The Boolean value</param>
        /// <param name="targetType">The target value</param>
        /// <param name="parameter">The parameter</param>
        /// <param name="culture">The culture of the value</param>
        /// <returns>Returns the a Visibility Type Value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
