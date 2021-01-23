    public class Table
    {
      public Table()
      {
         Parameters = new List<TableParameter>();
      }
       public enum ColumnNames
       {
           ID,
           TabloName,
           Active,
           Date
       }
    
       public List<TableParameter> Parameters { get; set; }
    }
