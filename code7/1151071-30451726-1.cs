    public class EnumWithDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                string output = value.GetType()
                    .GetTypeInfo()
                    .GetDeclaredField(((Enum)value).ToString())
                    .GetCustomAttribute<Display>()
                    .GetName();
                return output;
            }
            catch (NullReferenceException)
            {
                return ((Enum)value).ToString();
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
