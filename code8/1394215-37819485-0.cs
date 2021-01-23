    With reflection:
   
    public class Mapper()
    {      
      public Foo MapToFoo(List<string> list)
      { 
          Foo f = new Foo();
          var bars =  f.GetType().GetProperties();
          int i=0;
          foreach (var item in list)
          {
                bars[i++].SetValue(f, item);
                if(i==bars.Length)
                    break;
          }
          return f;
       }
    }
    public class Foo
    {
      public string Bar1 { get; set; }
      public string Bar2 { get; set; }
      public string Bar3 { get; set; }
    }
