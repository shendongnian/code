    public class MyPropertyDescriptor : PropertyDescriptor
    {
        PropertyDescriptor original;
        public MyPropertyDescriptor(PropertyDescriptor originalProperty)
            : base(originalProperty)
        {
            original = originalProperty;
        }
       
        // Implement other properties and methods simply using return original
        // The implementation is trivial like this one:
        // public override Type ComponentType
        // {
        //     get { return original.ComponentType; }
        // }
        public override bool ShouldSerializeValue(object component)
        {
            if (original.Attributes.OfType<DesignerSerializationVisibilityAttribute>()
                    .Count() == 0)
                return false;
            return original.ShouldSerializeValue(component);
        }
    }
