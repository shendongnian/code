    public abstract class Base
    {
       public abstract string LogicalName { get; }
       public abstract int NumberOfChars { get; }
       public Base()
       {
       } 
    }
    public class Derived1 : Base
    {
       public string LogicalName { get { return "Name1"; } } 
       public int NumberOfChars { get { return 30; } } 
       public Derived1() : base()
       {
        }
    }
