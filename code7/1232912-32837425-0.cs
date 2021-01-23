    public abstract class Parent
    {
    
      public Parent() 
      {
        // NullReferenceException here:
        var nameLength = Name.Length;
      }
    
      public abstract string Name { get; }
    
    }
    
    public class Child : Parent 
    {
    
      private string name;
    
      public Child()
      {
        name = "My Name";
      }
    
      public override string Name { get { return name; } }
    }
