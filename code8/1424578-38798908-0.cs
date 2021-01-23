    class GroupListConverter : TypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(GroupList));
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
                return true;
            return base.CanConvertTo(context, destType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
            {
                System.Reflection.ConstructorInfo ci = typeof(GroupList).GetConstructor(System.Type.EmptyTypes);
                return new InstanceDescriptor(ci, null, false);
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
