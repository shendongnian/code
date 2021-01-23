    // Register the validators and factory
    var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();   
    container.Register<IValidatorFactory, ApplicationValidatorFactory(Lifestyle.Singleton);
    container.Register(typeof(IValidator<>), assemblies);
    // Register Simple Injector validation factory in FV
    FluentValidationModelValidatorProvider.Configure(provider => {
    		provider.ValidatorFactory = new ApplicationValidatorFactory(container);
    		provider.AddImplicitRequiredValidator = false;
    	}
    );
