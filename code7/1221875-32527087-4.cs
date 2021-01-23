    public class Foo : ICustomTypeDescriptor
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P6 { get; set; }
        public string P7 { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            var properties = new[] { "P1", "P3", "P7" };
            var descriptors = TypeDescriptor
                .GetProperties(typeof(Foo))
                .Cast<PropertyDescriptor>()
                .Where(p => properties.Any(s => s == p.Name))
                .ToArray();
            return new PropertyDescriptorCollection(descriptors);
        }
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return new AttributeCollection(null);
        }
        string ICustomTypeDescriptor.GetClassName()
        {
            return null;
        }
        string ICustomTypeDescriptor.GetComponentName()
        {
            return null;
        }
        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return null;
        }
        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return null;
        }
        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return null;
        }
        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return null;
        }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return new EventDescriptorCollection(null);
        }
        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return new EventDescriptorCollection(null);
        }
        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(null);
        }
        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
