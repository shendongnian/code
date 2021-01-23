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
       private MyBaseClass baseClass;
       MyDerivedClass(MyBaseClass baseClass) 
       {
           this.baseClass = baseClass;
       }
      protected void MyMethod()
      {
        baseClass.MyMethod(MyConstantString);
      }
    }
