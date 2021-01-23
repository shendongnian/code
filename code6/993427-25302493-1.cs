    namespace CSharpWPF
    {
        class HyphenRemover : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string text = value as string;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text.Replace("-", string.Empty);
                }
                return value;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
