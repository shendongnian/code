    public class SerialNumberConverter : IValueConverter
    {
        private readonly string[] _serialNumberParts = new string[5];
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int serialPartIndex;
            if (!int.TryParse(parameter.ToString(), out serialPartIndex)
                || serialPartIndex < 0
                || serialPartIndex >= _serialNumberParts.Length
            )
                return Binding.DoNothing;
            string completeSerialNumber = (string) value;
            if (string.IsNullOrEmpty(completeSerialNumber))
            {
                for (int i = 0; i < _serialNumberParts.Length; ++i)
                    _serialNumberParts[i] = null;
                
                return "";
            }
            _serialNumberParts[serialPartIndex] = completeSerialNumber.Substring(serialPartIndex * 6, 5);
            return _serialNumberParts[serialPartIndex];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int serialPartIndex;
            if (!int.TryParse(parameter.ToString(), out serialPartIndex)
                || serialPartIndex < 0
                || serialPartIndex >= _serialNumberParts.Length
            )
                return Binding.DoNothing;
            _serialNumberParts[serialPartIndex] = (string)value;
            return (_serialNumberParts.Any(string.IsNullOrEmpty)) ?
                Binding.DoNothing :
                string.Join("-", _serialNumberParts);
        }
    }
