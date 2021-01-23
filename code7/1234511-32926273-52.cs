    public class ItemClickedToMySourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (MySource)(((ItemClickEventArgs)value).ClickedItem);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
