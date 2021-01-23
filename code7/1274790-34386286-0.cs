    public class DependencyResolverValidatorFactory : ValidatorFactoryBase
    {
        private readonly AutofacDependencyResolver resolver;
    
        public DependencyResolverValidatorFactory(AutofacDependencyResolver resolver)
        {
            this.resolver = resolver;
        }
    
        public override IValidator CreateInstance(Type validatorType)
        {
            return resolver.RequestLiftimeScope.ResolveOptionalKeyed<IValidator>(validatorType);
        }
    }
