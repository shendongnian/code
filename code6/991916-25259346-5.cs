    namespace CSharpWPF
    {
        class SignConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string text = value as string;
                double outValue;
                if (text != null && double.TryParse(text, out outValue))
                    return Math.Sign(outValue);
                return DependencyProperty.UnsetValue;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
