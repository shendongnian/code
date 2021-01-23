    abstract class BaseClass<T>
    {
        public T SomeMethod<T>(T aParam)
        {
            ...
            return aParam;
        }
    }
    
    class SubClass1 : BaseClass<string>
    {
        ...
    }
    
    class SubClass2 : BaseClass<int>
    {
        ...
    }
