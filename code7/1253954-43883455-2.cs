    public class ServiceProviderValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _serviceProvider;
    
        public ServiceProviderValidatorFactory(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;
    
        public override IValidator CreateInstance(Type validatorType)
            => (IValidator)_serviceProvider.GetService(validatorType);
    }
    public static class CompositionRoot
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            FluentValidationModelValidatorProvider.Configure(
                provider => provider.ValidatorFactory = 
                    new ServiceProviderValidatorFactory(container));
        }
    }
