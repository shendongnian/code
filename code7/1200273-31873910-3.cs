    public class PropertyResolver : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
                              object parameter, CultureInfo culture)
        {
            if (!(values[1] is Person)) throw new ArgumentException("please pass a person");
    
            var person = (Person)values[1];
            var property = values[0].ToString();
    
            return person.GetType().GetProperty(property).GetValue(person, null);
        }
    }
