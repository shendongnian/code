    public class SimpleInjectorValidatorFactory : ValidatorFactoryBase
    {
        private readonly Container _container;
    
        public SimpleInjectorValidatorFactory(Container container)
            => _container = container;
    
        public override IValidator CreateInstance(Type validatorType)
            => (IValidator)_container.GetInstance(validatorType);
    }
    public static class CompositionRoot
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            FluentValidationModelValidatorProvider.Configure(
                provider => provider.ValidatorFactory = 
                    new SimpleInjectorValidatorFactory(container));
        }
    }
