    public interface IParent 
    {
        // Defines members for the "parent" implementations
    }
    public interface IChild : IParent
    {
        // Implementors will be expected to fulfill the contract of
        // IParent AND whatever we define here
    }
    public class Parent : IParent
    {
        // Implements IParent members
    }
    public class Child : Parent, IChild
    {
         // Only has to implement the methods of IChild, 
         // Parent has already implement IParent
    }
