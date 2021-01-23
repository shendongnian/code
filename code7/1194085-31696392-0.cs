    // Custom lifestyle selection behavior
    public class AbstractBaseDerivativesAsSingleton : ILifestyleSelectionBehavior {
        public Lifestyle SelectLifestyle(Type serviceType, Type implementationType) {
            typeof(AbstractBase).IsAssignableFrom(implementationType)
                ? Lifestyle.Singleton
                : Lifestyle.Transient;
        }
    }
    // Usage
    var container = new Container();
    container.Options.LifestyleSelectionBehavior =
        new AbstractBaseDerivativesAsSingleton();
    container.RegisterSingle<Func<Derived1>>(() => container.GetInstance<Derived1>());
