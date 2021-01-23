    public enum Lifestyle { Transient = 0, Scoped = 1, Singleton = 2 }
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class LifestyleAttribute : Attribute {
        public LifestyleAttribute(Lifestyle lifestyle) {
            this.Lifestyle = lifestyle;
        }
        public Lifestyle Lifestyle { get; private set; }
    }
