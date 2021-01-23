    public static class MyClass
    {
       public static bool IsInited { get; private set; }
       public static void Init(...)
       {
          ...
          IsInited = true;
       }
    }
