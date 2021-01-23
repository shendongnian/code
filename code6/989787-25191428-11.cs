    public class AttributeLifestyleSelectionBehavior : ILifestyleSelectionBehavior {
        private const CreationPolicy DefaultPolicy = CreationPolicy.Transient;
        private readonly ScopedLifestyle scopedLifestyle;
        public AttributeLifestyleSelectionBehavior (ScopedLifestyle scopedLifestyle) {
            this.scopedLifestyle = scopedLifestyle;
        }
        public Lifestyle SelectLifestyle(Type serviceType, Type implementationType) {
           var attribute = implementationType.GetCustomAttribute<CreationPolicyAttribute>()
               ?? serviceType.GetCustomAttribute<CreationPolicyAttribute>();
           var policy = attribute == null ? DefaultPolicy : attribute.Policy;
           switch (policy) {
               case CreationPolicy.Singleton: return Lifestyle.Singleton;
               case CreationPolicy.Scoped: return this.scopedLifestyle;
               default: return Lifestyle.Transient;
           }
        }
    }
