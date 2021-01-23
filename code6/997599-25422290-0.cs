    public override bool CanConvertFrom(
        ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string);
    }
    public override object ConvertFrom(
        ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        return users.OfType<User>().First(u => u.ToString() == value.ToString()).Id;
    }
    public override object ConvertTo(
        ITypeDescriptorContext context, 
        CultureInfo culture, 
        object value, 
        Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            if (value is int)
            {
                return users.OfType<User>().First(u => u.Id == (int)value).ToString();
            }
            return value.ToString();
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
