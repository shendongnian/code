    public class PagedListArgs
    {
         public DataViewParts viewParts;
         public class DataViewParts
         {
             private string _type;
             public string Type
             {
                 get { return _type; }
                 set { _type = value; }
             }
    
             private string _filter;
             public string Filter
             {
                 get { return _filter; }
                 set { _filter = value; }
             }  
         }
    }
