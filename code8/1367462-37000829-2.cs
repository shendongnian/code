    public class FlowDirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var item = value as MyLanguage;
                if (item.language == "English")
                    return FlowDirection.LeftToRight;
                else
                    return FlowDirection.RightToLeft;
            }
            return FlowDirection.LeftToRight;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
