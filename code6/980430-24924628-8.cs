    public class EnumHelper : IValueConverter
    {
        public static IEnumerable<string> GetEnumDescriptions(Type enumType)
        {
            foreach (var item in Enum.GetNames(enumType))
            {
                FieldInfo fi = enumType.GetField(item);
                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                    yield return attributes[0].Description;
                else
                    yield return item;
            }
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return MyTypes.Float;
            Type enumType = typeof(MyTypes);
            foreach (var item in Enum.GetNames(enumType))
            {
                FieldInfo fi = enumType.GetField(item);
                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0 && string.Equals(attributes[0].Description, value))
                    return Enum.Parse(enumType, item);
            }
            return Enum.Parse(enumType, value.ToString());
        }
    }
