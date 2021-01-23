    public interface IMyClass<out T>
    {
        T MyProp { get; }
    }
    public class MyClass<T> : IMyClass<T>
    {
        public T MyProp { get; set; }
    }
    public IMyClass<object> ReturnWithDynamicParameterType()
    {
        //This function determines the type of T at runtime and should return instance of MyClass<T>
        return new MyClass<string>();
    }
