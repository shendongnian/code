    public class A
    {
        public string GetName()
        {
            return GetNameInternal();
        }
        internal virtual string GetNameInternal()
        {
            return "A";
        }
    }
    public class C : A
    {
        internal override string GetNameInternal()
        {
            return "C";
        }
    }
    // in other assembly
    public class B : A
    {
        // invalid due to scope:
        //internal override string GetNameInternal() { ... }
    }
