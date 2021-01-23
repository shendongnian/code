    public static class Constants
    {
      public const string MyConstant = "Hello world";
      public const int TheAnswer = 42;
    }
    class Foo
    {
      // ...
      private string DoStuff()
      {
        return Constants.MyConstant;
      }
    }
