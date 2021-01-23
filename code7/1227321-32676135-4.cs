    public static class MyClass
    {
       public static bool IsUnix { get; private set; }
       static MyClass()
       {
          IsUnix = Environment.NewLine == '\n';
       }
