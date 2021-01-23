    public static class LifestyleExtensions {
        public static void RegisterAccordingToLifestyleAttribute(
            this Container container, Type serviceType, Type implementation, 
            ScopedLifestyle scoped = null) {
            container.Register(serviceType, implementation, 
                GetLifestyleForType(implementation, scoped));
        }
        public static void RegisterOpenGenericAccordingToLifestyleAttribute(
            this Container container, Type serviceType, Type implementationType, 
            ScopedLifestyle scoped = null) {
            container.RegisterOpenGeneric(serviceType, implementationType,
                GetLifestyleForType(implementationType, scoped));
        }
        public static void RegisterManyForOpenGenericAccordingTolifestyleAttribute(
            this Container container, Type serviceType, ScopedLifestyle scoped = null, 
            params Assembly[] assemblies)
        {
            container.RegisterManyForOpenGeneric(serviceType, (s, i) => 
                container.RegisterAccordingToLifestyleAttribute(s, i.Single(), scoped),
                assemblies);
        }
        private static SimpleInjector.Lifestyle GetLifestyleForType(Type implementation,
            ScopedLifestyle scoped) {
            var attr = implementation.GetCustomAttribute<LifestyleAttribute>();
            var lifestyle = attr == null ? Lifestyle.Transient : attr.Lifestyle;
            switch (lifestyle) {
                case Lifestyle.Transient: return SimpleInjector.Lifestyle.Transient;
                case Lifestyle.Singleton: return SimpleInjector.Lifestyle.Singleton;
                default:
                    if (scoped == null) throw new InvalidOperationException(
                        "No scoped lifestyle supplied");
                    return scoped;
        }
    }
