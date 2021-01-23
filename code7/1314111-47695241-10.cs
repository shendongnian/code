     class AlternateColorConverter : IValueConverter
    {
        private static int idx_;
        private static int idx
        {
            get
            {
                idx_ = ((idx_ + 1) % 2);
                return idx_;
            }
        }
        public static Color GetColorFromHex(string hexString)
        {
            Color x = (Color)XamlBindingHelper.ConvertValue(typeof(Color), hexString);
            return x;
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var acolor = (idx % 2 == 0) ? new SolidColorBrush(GetColorFromHex("#F24C27")) : new SolidColorBrush(GetColorFromHex("#FBBA42"));
            return acolor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
