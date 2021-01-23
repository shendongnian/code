    void Main()
    {
      A realA = new A();
      A actuallyB = new B();
      
      Console.WriteLine(realA.GetName()); // John
      Console.WriteLine(actuallyB.GetName()); // Gillian
      
      PrintName(realA); // John
      PrintName(actuallyB); // Gillian
    }
    
    public void PrintName(A anyA)
    {
      Console.WriteLine(anyA.GetName());
    }
    
    public class A
    {
      public virtual string GetName() 
      {
        return "John";
      }
    }
    
    public class B : A
    {
      public override string GetName() 
      {
        return "Gillian";
      }
    }
