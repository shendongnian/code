    public class ChartDescriptionProvider : TypeDescriptionProvider
    {
        private static TypeDescriptionProvider _baseProvider = TypeDescriptor.GetProvider(typeof(Chart));
        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            // TODO: implement this
            return new Chart(...);
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
