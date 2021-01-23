    class ThreadSafeAsSingletonLifestyleSelectionBehavior : ILifestyleSelectionBehavior {
        public Lifestyle SelectLifestyle(Type serviceType, Type implementationType) {
            var sa = serviceType.GetCustomAttribute<ThreadSafeAttribute>();
            var ia = implementationType.GetCustomAttribute<ThreadSafeAttribute>();
            if (sa != null && ia == null) throw new InvalidOperationException(
                "If a service is annotated with [ThreadSafe] its implementation "+
                "type should also be registered with [ThreadSafe].");
            return ia == null ? Lifestyle.Transient : Lifestyle.Singleton;
        }
    }
