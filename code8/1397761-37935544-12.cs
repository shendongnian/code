    using System;
    using System.ComponentModel;
    using System.Linq; 
    class CustomBrushConverter : ExpandableObjectConverter
    {
        CustomBrush[] standardValues = new CustomBrush[] { new SolidCustomBrush(), new GradientCustomBrush() };
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var result = standardValues.Where(x => x.ToString() == value).FirstOrDefault();
            if (result != null)
                return result;
            return base.ConvertFrom(context, culture, value);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(standardValues);
        }
    }
