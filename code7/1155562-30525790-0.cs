    public class StringArrayDescriptionProvider : TypeDescriptionProvider
    {
        private static TypeDescriptionProvider _baseProvider;
        static StringArrayDescriptionProvider()
        {
           // get default metadata
            _baseProvider = TypeDescriptor.GetProvider(typeof(string[]));
        }
        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            // this is were we define create the instance
            // NB: .NET could do this IMHO...
            return Array.CreateInstance(typeof(string), 0);
        }
        public override IDictionary GetCache(object instance)
        {
            return _baseProvider.GetCache(instance);
        }
        public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance)
        {
            return _baseProvider.GetExtendedTypeDescriptor(instance);
        }
        public override string GetFullComponentName(object component)
        {
            return _baseProvider.GetFullComponentName(component);
        }
        public override Type GetReflectionType(Type objectType, object instance)
        {
            return _baseProvider.GetReflectionType(objectType, instance);
        }
        public override Type GetRuntimeType(Type reflectionType)
        {
            return _baseProvider.GetRuntimeType(reflectionType);
        }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return _baseProvider.GetTypeDescriptor(objectType, instance);
        }
        public override bool IsSupportedType(Type type)
        {
            return _baseProvider.IsSupportedType(type);
        }
    }
