    // T is covariant (i.e. the "out" keyword)
    public interface IGenericInterface<out T>
    {
        // Check that I removed the setter. T wouldn't be covariantly valid
        // if it could be set... 
        // BTW, this doesn't prevent an implementation to provide a setter.
        T GenericTypeProperty { get; }
        void PerformService(); 
    }
