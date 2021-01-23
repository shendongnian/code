    namespace WPFStack.Converters
    {
    public class PathToFilenameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = null;
    
            if (value != null)
            {
                var path = value.ToString();
    
                if (string.IsNullOrWhiteSpace(path) == false)
                    result = Path.GetFileNameWithoutExtension(path);
            }
    
            return result;
    
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    }
