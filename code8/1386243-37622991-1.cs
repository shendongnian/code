    public class NamedList<T> : List<T>
    {
         public NamedList(string name)
         {
              Name = name;
         }
         public string Name {get;set;}
    }
