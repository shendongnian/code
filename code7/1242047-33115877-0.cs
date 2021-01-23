    public interface IA { /* Nothing */ }
    public interface IB { /* Nothing */ }
    
    public class A : IA
    {
        int FirstItem { get; set; }  // This is an instance property.
    }
    
    public class B : IB
    {
        int SecondItem { get; set;}  // This is an instance property.
        Guid Indexer { get; set; }   // This is an instance property.
    }
    
    public class AExtendedByB : A
    {
        List<a> a = new List<A>();   // This is an instance field that is initialized before the constructor call. Your constructors are trivial (empty) anyway, so in this case it doesn't matter.
    }
