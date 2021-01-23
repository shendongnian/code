    public interface ITest
    {
        // general test stuff
    }
    
    // Type-specific stuff
    public interface ITesty<T> : ITest
    {
         public ITest SubTest { get; set; }    // a sub-test of any type
    }
