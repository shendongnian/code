    public class MyImmutableClass
    {
       public int MyAttribute { get; }
       private MyImmutableClass(int attribute, ...)
       {
           MyAttribute = attribute;
           ...
       }
       public static MyImmutableClass Create(int attribute)
       {
           return new MyImmutableClass(attribute, ...);
       }
    }
