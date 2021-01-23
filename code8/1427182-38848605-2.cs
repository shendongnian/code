    public abstract class NameStringClass : IName
    {
         public string Name { get; set; }
         public override string ToString()
         {
              return Name;
         }
    }
