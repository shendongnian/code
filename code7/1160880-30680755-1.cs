    class ComputationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int result = 0;
            ListView lv = parameter as ListView;
            Console.WriteLine(lv.Items);
            foreach (var item in lv.Items)
            {
                result += (int)item;
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
