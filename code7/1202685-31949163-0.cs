    public class LogicalNameAttribute : Attribute
    {
         public LogicalNameAttribute(string name)
         {
              Name = name;
         }
         public string Name { get; private set; }
    }
    public class NumberOfCharsAttribute : Attribute
    {
         public NumberOfCharsAttribute (int number)
         {
              Number = number;
         }
         public string Number { get; private set; }
    }
    [LogicalName("Name1"), NumberOfChars(30)]
    public class Derived1 : Base
    {
       public Derived1() : base()
       {
    
        }
    }
