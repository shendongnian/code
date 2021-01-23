    public class SpecialDateConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
           var date = (DateTime)value;
           return string.Format("{0}->{1}", date.ToString("MM\\/dd hh"), date.AddHours(1).ToString("hh"));
        }
        public object ConvertBack(
            object value, 
            Type targetType, 
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
