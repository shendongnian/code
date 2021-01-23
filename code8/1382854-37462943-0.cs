    [TypeConverter(typeof(BusinessObjectIdConverter))]
    public class BusinessObjectId
    { ... }
    public class BusinessObjectIdConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return new BusinessObjectId((string)value);
        }
    }
