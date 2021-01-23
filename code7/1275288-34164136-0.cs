    public class BoolTypeConverter : System.ComponentModel.BooleanConverter
    {
        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            try
            {
                if (value.ToString() == Resources.BoolTypeConverter_True)
                    return true;
                else if (value.ToString() == Resources.BoolTypeConverter_False)
                    return false;
                else
                    return false;
            }
            catch
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            try
            {
                if ((bool)value == true)
                    return Resources.BoolTypeConverter_True;
                else if ((bool)value == false)
                    return Resources.BoolTypeConverter_False;
                else
                    return Resources.BoolTypeConverter_False;
            }
            catch
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
