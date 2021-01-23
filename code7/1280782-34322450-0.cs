    public class PagedListArgs
    {
         public PagedListArgs(){
             DataViewParts = new DataViewParts();
         }
         public DataViewParts DataViewParts { get; set; }
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
