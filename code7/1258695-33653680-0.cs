    public class AnyListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as IEnumerable<SampleClass>;
            if (list == null)
                return null;
            // Do conversion here
            var sb = new StringBuilder();
            foreach (var sample in list)
            {
            }
            return sb.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valuestring = value as string;
            if (string.IsNullOrEmpty(valuestring))
                return null;
            // Do some conversion back to some List
            // for example
            var list = (from sampleString in valuestring.Split(....) select new Sample(sampleString)).ToList();
            // Convert to the Targetlist
            var converted = Activator.CreateInstance(targetType, list);
            return converted;
        }
    }
