    class intFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var intField = (int)value;
            switch (intField)
            {
                case 0:
                    return "Foo";
                case 1:
                    return "Bar";
                default:
                    return default(string);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
