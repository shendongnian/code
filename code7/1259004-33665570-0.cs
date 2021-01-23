    public class Program
    {
      Class1 myClass = new Class1();
      public Class1 MyClass{get{return myClass;}}
    }
    static void godmode()
    {
      Program p = new Program();
      var myClass = p.MyClass;
    }
