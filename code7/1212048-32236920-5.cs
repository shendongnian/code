    class NumericDecimalConverter : DecimalConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string text = ((string)value).Trim();
                if (culture == null) 
                    culture = CultureInfo.CurrentCulture;
                NumberFormatInfo formatInfo = (NumberFormatInfo)culture.GetFormat(typeof(NumberFormatInfo));
                return Double.Parse(text, NumberStyles.Number, formatInfo);
            }
            else
            {
                return base.ConvertFrom(value);
            }
        }
    }
