    class AlternateColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = (int)value;
            var color=(val%2==0) ? new SolidColorBrush(new Color { A = 255, R = 240, G = 255, B = 240 }): new SolidColorBrush(new Color { A = 255, R = 230, G = 230, B = 250 });
            return color;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
