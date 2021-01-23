    public class FirstAndLastnameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
    		var emp = value as Employee;
            return  string.Format("{0} {1}", emp.FirstName, emp.LastName);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
