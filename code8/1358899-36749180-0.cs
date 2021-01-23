        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int data;
            if (string.IsNullOrEmpty((string)value) || !int.TryParse((string)value, out data))
            {
                return null;
            }
            else
            {
                return data;
            }
        }
