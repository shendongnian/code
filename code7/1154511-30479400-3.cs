    public class TemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int osValue = System.Convert.ToInt32(value);
            var myResourceDictionary = new ResourceDictionary();
            
            myResourceDictionary.Source =
                new Uri("/MyApp;component/Dictionary1.xaml",
                        UriKind.RelativeOrAbsolute);  
            if(osValue < 6)
                return myResourceDictionary["OldTemplate"];
            else
                return myResourceDictionary["NewTemplate"];
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
 
