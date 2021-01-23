    public class StatusToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool? b = (bool?)value;
                if (b == true) return "activated";
                else if (b == false) return "deactivated";
                else return "not set";
            }
            catch (Exception)
            {
                return "invalid";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool? returnValue = null;
                string s = (string)value;
                if (s == "activated") returnValue = true;
                else if (s == "deactivated") returnValue = false;
                return returnValue;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
