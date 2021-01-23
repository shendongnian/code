    public class MyTypeDescriptionProvider : TypeDescriptionProvider
    {
        public MyTypeDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(object))) { }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType,
                                                                object instance)
        {
            ICustomTypeDescriptor baseDes = base.GetTypeDescriptor(objectType, instance);
            return new MyTypeDescriptor(baseDes);
        }
    }
