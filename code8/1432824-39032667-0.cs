    public class MyClassConverter : TypeConverter
    {
        private List<string> values = new List<string>();
        public MyClassConverter()
        {
            values.Add("Value1");
            values.Add("Value2");
            values.Add("Value3");
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is int)
            {
                int index = (int)value;
                if (index >= 0 && index < values.Count)
                    return values[index];
                return values[0]; // error, go back to first
            }
            return value;
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string s = value as string;
            if (s != null)
            {
                int index = values.IndexOf(s);
                if (index >= 0)
                    return index;
                // support direct integer input & validate
                if (int.TryParse(s, out index) && index >= 0 && index < values.Count)
                    return index;
                return 0; // error, go back to first
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(values);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
