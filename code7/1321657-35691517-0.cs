    internal class AnyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (int)(Models.Word.Categories)value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (Models.Word.Categories)(int)value;
        }
    }
