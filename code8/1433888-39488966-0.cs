    [ValueConversion(typeof(List<Item>),typeof(string))]
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<Item> items = (List<Item>)value;
            string supplementsString = string.Empty;
            if (items.Count >= 1)
            {
                foreach (var item in items)
                {
                    supplementsString += item.Name + " " + item.Price.ToString() + " " + Environment.NewLine;
                }
            }
            return supplementsString;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
