    class SomeItem
    {
      private readonly string name;
      private readonly string description;
      
      public SomeItem(string name, string description)
      {
        this.name = name;
        this.description = description;
      }
      
      public SomeItem With
        (
          Option<string> name = null,
          Option<string> description = null
        )
      {
        return new SomeItem
          (
            name.GetValueOrDefault(this.name), 
            description.GetValueOrDefault(this.description)
          );
      }
    }
