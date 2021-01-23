    public class SimpleTypeParameterBindingFactory
    {
        private readonly TypeConverterModelBinder converterModelBinder = new TypeConverterModelBinder();
        private readonly IEnumerable<ValueProviderFactory> factories;
        public SimpleTypeParameterBindingFactory(HttpConfiguration configuration)
        {
            factories = configuration.Services.GetValueProviderFactories();
        }
        public HttpParameterBinding BindOrNull(HttpParameterDescriptor descriptor)
        {
            return IsSimpleType(descriptor.ParameterType)
                ? new ModelBinderParameterBinding(descriptor, converterModelBinder, factories)
                : null;
        }
        private static bool IsSimpleType(Type type)
        {
            return TypeDescriptor.GetConverter(type).CanConvertFrom(typeof (string));
        }
    }
    public class Startup
    {
        public void Configure(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            configuration.ParameterBindingRules.Insert(0, new SimpleTypeParameterBindingFactory(configuration).BindOrNull);
            configuration.EnsureInitialized();
        }
    }
