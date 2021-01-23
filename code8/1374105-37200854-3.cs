    public class ButtonStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Uri resourceLocater = new Uri("/YourNameSpace;component/ButtonStyles.xaml", System.UriKind.Relative);
            ResourceDictionary resourceDictionary = (ResourceDictionary)Application.LoadComponent(resourceLocater);
            if (value.ToString() == "Some Value")
            {
                return resourceDictionary["ButtonStyle1"] as Style;
            }
            return resourceDictionary["ButtonStyle2"] as Style;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
