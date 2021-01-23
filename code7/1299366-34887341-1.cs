    public class XamlTextToObjectConverter : IValueConverter
    {
        private static readonly Regex Regex = new Regex("(<.*?)>(.*)(</.*?>)", RegexOptions.Compiled);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var xamlText = value as string;
            if (xamlText != null)
            {
                var xamlTextWithNamespace = Regex.Replace(xamlText, "$1 xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">$2$3");
                try
                {
                    return XamlReader.Parse(xamlTextWithNamespace);
                }
                catch (Exception) // catch proper exceptions here, not just Exception
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
