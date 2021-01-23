    namespace CSharpWPF
    {
        class SignConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double outValue;
                if (value != null && double.TryParse(value.ToString(), out outValue))
                    return Math.Sign(outValue);
                return DependencyProperty.UnsetValue;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
