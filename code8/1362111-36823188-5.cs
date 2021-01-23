    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color clr = Colors.SteelBlue;
            var s = value as String;
            //  Add code here to pick a color or generate RGB values for one
            switch (s) {
                case "1":
                    clr = Colors.Black;
                    break;
            }
            return new SolidColorBrush(clr); 
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
