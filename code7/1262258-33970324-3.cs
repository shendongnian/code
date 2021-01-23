    public class MyReferenceTypeonverter : TypeConverter
    {
        private Type ContainerType = typeof(Deklaration);
        private const string empty = "(none)";
        Dictionary<string, MyReferencableObject> values;
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string FullName = (string)value;
            if (FullName == empty)
                return null;
            InitDict(context);
            if (values.ContainsKey(FullName))
                return values[FullName];
            return value;
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value == null)
                return empty;
            InitDict(context);
            foreach (string key in values.Keys)
                if (key != empty)
                    if (values[key].FullName == ((MyReferencableObject)value).FullName)
                        return key;
            //sometimes happens...
            return "ERROR!!!";
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            InitDict(context);
            return new StandardValuesCollection(values.Values);
        }
        void InitDict(ITypeDescriptorContext context)
        {
            //sometimes happens...
            if (context == null)
                return;
            Dictionary<string, MyReferencableObject> tvalues = new Dictionary<string, MyReferencableObject>();
            tvalues.Add(empty, null);
            ITypeDiscoveryService Service = (ITypeDiscoveryService)context.GetService(typeof(ITypeDiscoveryService));
            //sometimes happens...
            if (Service == null)
                return;
            foreach (Type declaration in Service.GetTypes(ContainerType, false))
                foreach (FieldInfo fieldInfo in declaration.GetFields())
                    if (context.PropertyDescriptor.PropertyType.IsAssignableFrom(fieldInfo.FieldType))
                    {
                        MyReferencableObject var = (MyReferencableObject)fieldInfo.GetValue(null);
                        var.FieldInfo = fieldInfo;
                        tvalues.Add(var.FullName, var);
                    }
            //in a perfect world the if should not be necessary....
            if (tvalues.Count > 1 || values == null)
                values = tvalues;
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(value, attributes);
        }
    }
