    public class MySeconComboBoxValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //first item is the selected Item of the first box. For this example, assume it's the key to a dictionary that defines what I want in the second box:
            string key = values[0] as string;
    
            //second item looks up what we want in our second combobox using the first's as a key
            Dictionary<string, List<string>> dictionary = values[1] as Dictionary<string, List<string>>;
    
            //pass our value to be bound to
            return dictionary[key].Keys.ToList();
        }
    }
