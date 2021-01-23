    public class MyConverter : IMultiValueConverter
    {  
        public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var control = values[0] as FrameworkElement;
            var value1 = values[1] as int;
    
            // write your logic here.          
        }
     
        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return throw new System.NotImplementedException();;
        }
    }
