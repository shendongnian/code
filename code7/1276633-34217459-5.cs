    class TestMultiBindingConverter : IMultiValueConverter
    {
        private bool _hadError;
        public object Convert(object[] values,
            Type targetType, object parameter, CultureInfo culture)
        {
            bool? isFocused = values[1] as bool?,
                hasError = values[2] as bool?;
            if ((hasError == true) || _hadError)
            {
                _hadError = true;
                return Binding.DoNothing;
            }
            if (values[0] != null)
            {
                 return values[0].ToString() + (isFocused == true ? "" : " (+)");
            }
            return DependencyProperty.UnsetValue;
        }
        public object[] ConvertBack(object value,
            Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                double doubleValue;
                var stringValue = value.ToString();
                if (Double.TryParse(stringValue, out doubleValue))
                {
                    object[] values = { doubleValue };
                    _hadError = false;
                    return values;
                }
            }
            object[] values2 = { DependencyProperty.UnsetValue };
            return values2;
        }
    }
