    public class IsEnabledCheckConverter : IMultiValueConverter
    {  
        public object Convert(object[ ] values, Type targetType, object parameter, CultureInfo culture)
    {
          if(Convert.ToBoolean(values[0]) && Convert.ToBoolean(values[1]))
            {
                return true;
            }
         return false;        
    }
    public object Convert(object[ ] values, Type targetType, object parameter, CultureInfo culture)
    {
         //convert back Logic
    }
    }
