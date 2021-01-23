    public class AutoRegistration: IAutoRegistration
    {
        public void Register(IServiceContainer container)
        {
            // where the type of Add<> is IAutoRegistration
            container.Add<SomeDependentNamespace.AutoRegistration>();
            container.Add<SomeOtherDependentNamespace.AutoRegistration>();
        }
    }
