    public interface MyInterface // This is the non-generic interface.
    {
        object MyObject { get; set; }
    }
    public interface MyInterface<T> // This is the generic interface.
        where T : MyOtherBaseClass
    {
        T MyObject { get; set; }
    }
    public abstract class MyBaseClass<T> : MyInterface, MyInterface<T> // This class implements both the non-generic and the generic interface.
      where T : MyOtherBaseClass
    {
        public T MyObject { get; set; } // Implementation of the generic property.
        object MyInterface.MyObject // Implementation of the non-generic property.
        {
            get { return MyObject; }
            set { MyObject = (T)value; }
        }
    }
    ...
    MyInterface baseObject; // The non-generic interface is used as base object.
    baseObject = new MyImplementation(); // It is assigned an instance of MyImplementation which uses a generic base class.
    object value = baseObject.MyObject;
     
