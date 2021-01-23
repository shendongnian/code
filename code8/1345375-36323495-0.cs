    public interface IGeneric<out T> where T : BaseClass, new() { }
    public class GenericClass<T> : IGeneric<T> where T : BaseClass, new() { }
    
    public interface IBase { }
    public class BaseClass { }
    public class SubClass : BaseClass { }
