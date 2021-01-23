    public class ItemConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            System.Diagnostics.Debug.WriteLine(value.GetType());
            var item = value as Item;
            return string.Format("Name: {0}, Number {1}", item.Name, item.Number);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
