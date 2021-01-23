    public class CustomSizeConverter : ExpandableObjectConverter
    {
        TypeConverter converter;
        public CustomSizeConverter()
        {
            converter = TypeDescriptor.GetConverter(typeof(Size));
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return converter.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            try
            {
                return converter.ConvertFrom(context, culture, value);
            }
            catch (Exception)
            {
                var d= context.PropertyDescriptor.Attributes.OfType<DefaultValueAttribute>().FirstOrDefault();
                if (d != null)
                    return d.Value;
                else
                    return new Size(0,0);
            }
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return converter.ConvertTo(context, culture, value, destinationType);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return converter.CanConvertTo(context, destinationType);
        }
    }
