    var container = new UnityContainer();
    container.RegisterType<IRuleProvider, RuleProvider>(
                "rulesprovider",
                new InjectionConstructor(HostingEnvironment.MapPath("~/Rules/Rates/upload/rules.xml")));
    container.RegisterType<IValidationEngine, ValidationEngine>(
                new InjectionConstructor(
                new ResolvedParameter<IRuleProvider[]>()));
    var validationEngine = container.Resolve<IValidationEngine>();
