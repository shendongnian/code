      object ImportantVariable { get; } // I prefer exposing this 
                                        // kind of thing as a readonly 
                                        // property but it's up to you
      object ImportantVariable2 { get; }
      object ImportantVariable3 { get; }
      object ImportantVariable4 { get; }
    }
    public class Object : IImportantVariables
    {
      // Implementation as before
    }
    
    public class DependentClass1 
    {
      public DependentClass1(IImportantVariables variables)
      {
        // ...
      }
    }
