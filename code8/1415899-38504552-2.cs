    public class MyTypeDescriptor : CustomTypeDescriptor
    {
        ICustomTypeDescriptor original;
        public MyTypeDescriptor(ICustomTypeDescriptor originalDescriptor)
            : base(originalDescriptor)
        {
            original = originalDescriptor;
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetProperties(new Attribute[] { });
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = base.GetProperties(attributes).Cast<PropertyDescriptor>()
                                 .Select(p => new MyPropertyDescriptor(p))
                                 .ToArray();
            return new PropertyDescriptorCollection(properties);
        }
    }
