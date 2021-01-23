    public class MyTypeDescriptionProvider : TypeDescriptionProvider
    {
        public MyTypeDescriptionProvider()
           : base(TypeDescriptor.GetProvider(typeof(object))) { }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, 
                                                                object instance)
        {
           ICustomTypeDescriptor baseDescriptor = base.GetTypeDescriptor(objectType, instance);
           return new MyTypeDescriptor(baseDescriptor);
        }
    }
