    public class ShortcutKeysConverter : KeysConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (Type.Equals(destinationType, typeof(string)) && value is Keys)
            {
                var key = (Keys)value;
                if (key.HasFlag(Keys.Oemcomma))
                {
                    string defaultDisplayString =
                        base
                            .ConvertTo(context, culture, value, destinationType)
                            .ToString();
                    return defaultDisplayString.Replace(Keys.Oemcomma.ToString(), ",");
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
