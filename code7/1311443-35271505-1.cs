    public class MyConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, 
        Type sourceType)
        {
            return sourceType == typeof(Base);
        }
 
    public override object ConvertFrom(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            return value as Base;
        }
 
    public override bool CanConvertTo(ITypeDescriptorContext context, 
        Type destinationType)
        {
            return destinationType == typeof(Base);
        }
 
    public override object ConvertTo(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return value == null ? null : value as Base;
        }
    }
