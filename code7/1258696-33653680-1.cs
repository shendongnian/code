    public class AnyListToStringConverter : IValueConverter
    {
        private const char delimiter = ';'; // delimiter to join
        private const char[] delimiters = {';', ',', '.', ':', ' '}; // possible delimiters, which might be in the string when converting back
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as IEnumerable<PhoneNumber>;
            if (list == null)
                return null;
            // Do conversion here
            var sb = new StringBuilder();
            foreach (var sample in list)
            {
                sb.Append(nummer.ToString()).Append("; "); // join it to a string
            }
            return sb.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valuestring = value as string;
            if (string.IsNullOrEmpty(valuestring))
                return null;
            // Do some conversion back to some List
            //var list = (from sampleString in valuestring.Split(....) select new Sample(sampleString)).ToList();
            // For example conversion back
            var list = numbersstring.Split(delimiters).Select(phoneNumber => phoneNumber.Trim()) // split the string
                .Where(phoneNumber => !string.IsNullOrEmpty(phoneNumber)) // sort out hollow Nuts :)
                .Select(phoneNumber => new PhoneNumber(phoneNumber)) // recreate Phonnumber Objects
                .Where(numberobj => numberobj.IsValidPhoneNumber) // Test if the result is a correct Phonenumber
                .ToList();
            // Convert to the Targetlist by invoking its constructor, passing the created list.
            var converted = Activator.CreateInstance(targetType, list);
            return converted;
        }
    }
