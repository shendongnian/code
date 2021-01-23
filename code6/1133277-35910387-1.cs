    public class AnotherClass
    {
        public void Method()
        {
            SomeClass.ObsoleteMethod();  // Compiler error
        }
        [Obsolete("Avoid use",false)]
        public void AnotherObsoleteMethod()
        {
            SomeClass.ObsoleteMethod(); // No error and no warning
        }
    }
