    // T is covariant (i.e. the "out" keyword)
    interface IGenericInterface<out T>
    {
        T GenericTypeProperty {get; set;}
        void PerformService(); 
    }
