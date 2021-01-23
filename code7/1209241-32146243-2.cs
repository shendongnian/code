    public class MyPriceToBackgroundConverter : IValueConverter
    {
        private static MyPriceToBackgroundConverter instance;
        public static MyPriceToBackgroundConverter Instance
        {
            get
            {
                if (instance == null)
                    instance = new MyPriceToBackgroundConverter();
                return instance;
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            if (price > 8 && price < 12)
                return Brushes.Red;
            return Brushes.Azure;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Useless here
            throw new NotImplementedException();
        }
    }
