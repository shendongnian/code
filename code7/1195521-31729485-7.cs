    public class SomeClass
    {
        public readonly Action someMethod;
        public SomeClass(Action<SomeClass> someMethod) { this.someMethod = ()=>someMethod(this); }
        public SomeClass(Action someMethod) { this.someMethod = someMethod; }
        public SomeClass()
        {
            this.someMethod = this.defaultSomeMethod;
        }
        private void defaultSomeMethod()
        {
        }
        public void SomeOtherMethod() {}
    }
    public class Program
    {
        static void YMain()
        {
            var someClassInstance =
            new SomeClass
            (
                someMethod :
                @this=>
                {
                    @this.SomeOtherMethod();
                    // do other stuff
                }
            );
            someClassInstance.someMethod();
        }
    }
