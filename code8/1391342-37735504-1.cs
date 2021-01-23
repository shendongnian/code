    public class IBANTypeConverter : TypeConverter
    {
    	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    	{
    		if (destinationType == typeof(string))
    			return IBAN.Format(value as string);
    		return base.ConvertTo(context, culture, value, destinationType);
    	}
    }
