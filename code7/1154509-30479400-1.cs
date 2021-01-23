    public class TemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int osValue = System.Convert.ToInt32(value);
            var myResourceDictionary = new ResourceDictionary();
            
            myResourceDictionary.Source =
                new Uri("/ReallyDeleteMe;component/Dictionary1.xaml",
                        UriKind.RelativeOrAbsolute);  
            if(osValue != 5)
                return myResourceDictionary["ItemTemplate"];
            else
                return myResourceDictionary["SelectedTemplate"];
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
 
