    public class MyCollectionTypeConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is List<string>)
            {
                return string.Join(",", ((List<string>) value).Select(x => x));
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
