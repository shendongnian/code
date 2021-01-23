    public class Foo
    {
     public string Prop { get;set; }
     public Foo(string prop)
     {
      Prop = prop;
     }
    
     public static Foo Create(string prop)
     {
      return new Foo(prop);
     } 
    }
