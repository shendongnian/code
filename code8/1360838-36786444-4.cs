    public abstract class ClassAB : IDestination //might not need the interface
    {
      public virtual string Var1 { get; set; }
      public virtual string Var2 { get; set; }
      public virtual string Var3 { get; set; }
      public virtual string Var4 { get; set; }
      public virtual string Var5 { get; set; }
    }
    public class ClassA : ClassAB
    {
       //override any of the virtual methods needed
    }
    public class ClassB : ClassAB
    {
       //override any of the virtual methods needed
    }
