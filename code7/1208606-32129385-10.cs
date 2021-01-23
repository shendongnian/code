    public abstract class AEnum<T, T3> where T3 : B<T>, new()
    {
        private static Func<A<T>> factoryMethod;
        public static readonly Level1 = new AEnum<T>(()=>new A<T>());
        public static readonly Level2 = new AEnum<T>(()=>new B<T>());
        public static readonly Level3 = new AEnum<T>(()=>new T3());
        protected AEnum(Func<A<T>> factoryMethod) { this.factoryMethod = factoryMethod; }
        public A<T> New() { return this.factoryMethod(); }
    }
    
