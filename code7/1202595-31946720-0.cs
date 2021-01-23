    public class ConditionalCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var output = 0;
    
            var collection = value as List<MyClass>();
    
            if(collection != null)
            {
                output = collection.Count(i => i.DoesMeetMyCriteria == true);
            }
    
            return output;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
