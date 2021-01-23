    public abstract class MyBaseClass
    {
      private readonly string myString;
      
      protected MyBaseClass(string myString)
      {
        this.myString = myString;
      }
    
      protected void MyMethod()
      {
        //...
      }
    }
    
    public abstract class MyDerivedClass : MyBaseClass
    {
      protected MyBaseClass() : base("Hello") {}
    }
