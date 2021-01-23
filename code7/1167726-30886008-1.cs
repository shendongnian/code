    public interface IBase 
    {
        // Defines members for the base implementations
    }
    public interface IDerived : IBase
    {
        // Implementors will be expected to fulfill the contract of
        // IBase *and* whatever we define here
    }
    public class Base : IBase
    {
        // Implements IBase members
    }
    public class Derived : Base, IDerived
    {
         // Only has to implement the methods of IDerived, 
         // Base has already implement IBase
    }
