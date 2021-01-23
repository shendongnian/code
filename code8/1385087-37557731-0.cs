    public class DecimalUpDownValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // handle input on a case-to-case basis
            if(value == null)
            {
                // Do something
                return 0;
            }
            else
            {
                return value;
            }
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // Do the conversion from model property to DecimalUpDownValue
            return value;
        }
    }
