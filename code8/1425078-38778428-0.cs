    class MyClass
    {
       // A read-only property that can only be set with a property initializer
       // or in a static constructor
       private static TimeSpan MyProperty { get; } = TimeSpan.FromSeconds(5);
    
       public void SomeMethod()
       {
           // usage of field
       }
    }
