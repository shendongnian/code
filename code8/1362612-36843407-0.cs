    public class MyClass
    {
      private MyClass() { ... }
      public static MyClass createInstance() {
        MyClass instance = new MyClass();
        instance.Initialize();
        return instance;
      }
    }
