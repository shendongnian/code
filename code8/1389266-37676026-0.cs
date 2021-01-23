    abstract class MyBaseClass
    {
      void MyMethod(string myVariable)
      {
        //...
      }
    }
    abstract class MyDerivedClass
    {
       static readonly string MyConstantString = "Hello";
       private MyBaseClass base;
       MyDerivedClass(MyBaseClass base) 
       {
           this.base = base;
       }
      protected void MyMethod()
      {
        base.MyMethod(MyConstantString);
      }
    }
