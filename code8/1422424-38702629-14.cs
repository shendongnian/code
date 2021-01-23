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
            var properties = original.GetProperties().Cast<PropertyDescriptor>().ToList();
            var parent = properties.Where(x => x.Name == "MyField").First();
            var sub = TypeDescriptor.GetProperties(typeof(FieldType))["Value"];
            properties.Remove(parent);
            properties.Add(new MyPropertyDescriptor(parent, sub));
            return new PropertyDescriptorCollection(properties.ToArray());
        }
    }
