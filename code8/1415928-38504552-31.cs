    public class MyPropertyDescriptor : PropertyDescriptor
    {
        PropertyDescriptor original;
        public MyPropertyDescriptor(PropertyDescriptor originalProperty)
            : base(originalProperty) { original = originalProperty;}
        public override AttributeCollection Attributes
        {
            get
            {
                var attributes = base.Attributes.Cast<Attribute>();
                var result = new List<Attribute>();
                foreach (var item in attributes)
                {
                    if(item is IMetadatAttribute)
                    {
                        var attrs = ((IMetadatAttribute)item).Process();
                        if(attrs !=null )
                        {
                            foreach (var a in attrs)
                                result.Add(a);
                        }
                    }
                    else
                        result.Add(item);
                }
                return new AttributeCollection(result.ToArray());
            }
        }
        // Implement other properties and methods simply using return original
        // The implementation is trivial like this one:
        // public override Type ComponentType
        // {
        //     get { return original.ComponentType; }
        // }
    }
