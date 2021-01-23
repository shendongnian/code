    protected IGenericBase<Interface1> genericInstance = new Customer();
    
    public interface IGenericBase<out T> {}
    
    public abstract class GenericBase<T> : IGenericBase<T>
        where T:Interface1 {}
    
    public interface Interface1 {}
    
    public class Type1 : Interface1 {}
    
    public class Customer: GenericBase<Type1> {}
