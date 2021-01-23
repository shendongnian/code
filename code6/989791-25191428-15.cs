    public enum CreationPolicy { Transient, Scoped, Singleton };
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface,
        Inherited = false, AllowMultiple = false)]
    public sealed class CreationPolicyAttribute : Attribute {
        public CreationPolicyAttribute(CreationPolicy policy) {
            this.Policy = policy;
        }
    
        public CreationPolicy Policy { get; private set; }
    }
