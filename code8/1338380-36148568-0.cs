    public class BoolFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value.ToString() == "true" || value.ToString() == "True")
            {
                return true;
            }
            else if (value.ToString() == "false" || value.ToString() == "False")
            {
                return false;
            }
            else
            {
                return "";
            }
        }
    }
