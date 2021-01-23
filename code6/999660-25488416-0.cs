    abstract class AbstractBaseClass
    {
        abstract void DoThis();
        abstract void DoThat();
    }
    
    abstract class AbstractClass<T>
        : AbstractBaseClass
    {
        override void DoThis(){...}
        override void DoThat(){...}
        public T Items{...}
    }
