    public abstract class BaseClass<TIdentifier> {
        public virtual object Me { get { return this; } }
    }
    
    public class A: BaseClass<long>
    {
        public override A Me { get { return this; } } // wont work in C#
    }
    
    public class B: BaseClass<long>
    {
        public override B Me { get { return this; } } // wont work in C#
    }
