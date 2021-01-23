    abstract class AbstractBase<T> where T: Baseclass
    {
        public abstract T MyProperty { get; set;}
    }
    class Implementation_A_OfAbstractBase : AbstractBase<InherritedBaseClassA>         
    {
        //you no longer need to override the property, the generic type takes care of this for you.
    }
