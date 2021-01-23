    public class StringMaxLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int MaxLength = Convert.ToInt32(parameter);
            string TheString = (string)Value;
            if (MaxLength > TheString.Length)
            {
                return TheString.SubString(0, MaxLength);
            }
            else
            {
                return TheString;
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
