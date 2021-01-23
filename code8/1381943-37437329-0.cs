    class InternalHelper<T> {
     internal T MyProp { get; }
    }
    
    public class MySubClass
    {
     InternalHelper<MyInternalClass> helper;
    }
