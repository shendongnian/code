    public class ServerInstance : MarkupExtension, IMultiValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object[] values, Type targetType, 
            object parameter, CultureInfo culture)
        {
            var server = $"{values[0]}0";
            var instance = $"{values[1]}";
            if (instance == "")
                return server;
            if (server == "")
                return "";
            return $"{server}\\{instance}";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, 
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
