    public class ExampleConverter : GenericConverter<string>
    {
        public override object Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO: Convert implementation
            return value;
        }
        public override object ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO: ConvertBack implementation
            return value;
        }
    }
