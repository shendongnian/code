    public abstract class MyBaseClass
    {
      protected abstract string MyConstantString { get; }
    
      protected void MyMethod()
      {
        //...
      }
    }
    
    public abstract class MyDerivedClass : MyBaseClass
    {
      protected override sealed string MyConstantString => "Hello";
    }
