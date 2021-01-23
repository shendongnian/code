    public class Foo
    {
      public string MyProp{get;set;}
     public string SerarchParam{get;set;}
     public bool SearchResult{
               get 
                   {
                     return this.MyProp && this.MyPro.Contains(SearchParam);
                   }
       }
    }
