    public class B : A
    {
     private string foo = "test";
     [Bar(1, 2)]
     public override string Foo
     {
      get { return foo; }
      set { foo = value; }
     }
    } 
