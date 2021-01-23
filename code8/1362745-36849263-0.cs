    public class PrincipleClass
    {
      public ClassB InstanceOfClassB { get; private set; }
      public ClassA InstanceOfClassA { get; private set; }
    
      public PrincipleClass(string db_file)
      {
        InstanceOfClassA = new ClassA(new SQLiteConnection(db_file));
        InstanceOfClassB = new ClassB();
      }
      //More code here
    }
    
    public class ClassA
    {
      public ClassA(SQLiteConnection handle)
      {
         // your code here
      }
      public void FunctionOfA1() { }
      public void FunctionOfA2() { }
    }
    
    public class ClassB
    {
      public void FunctionOfB1() { }
      public void FunctionOfB2() { }
    }
