    public class MyClass {
      public MyClass() {
        Value = 0.0;
      }
      public Double? Value {
        get;
        set;
      }
    }
    ...
    MyClass test = new MyClass();
    ApplyNullsForZeroes(test);
    if (test.Value == null)
      Console.Write("It's null now");
