    class MyBaseClass
    {
      public virtual string Name { get; set; }
    }
  
  
    class MyDerivedClass : MyBaseClass
    {
      private string name;
  
     // Override auto-implemented property with ordinary property
     // to provide specialized accessor behavior.
      public override string Name
      {
          get
          {
              return name;
          }
          set
          {
              if (value != String.Empty)
              {
                  name = value;
              }
              else
              {
                  name = "Unknown";
              }
          }
      }
    }
