    public class ListToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is IEnumerable)
            {
                string retval ="";
                for(string item in (IEnumerable)value) //use your string format here
                    retval+= item+",";
            }
    
            else 
                return "";
    
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
