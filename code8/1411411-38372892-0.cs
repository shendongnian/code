    public abstract class BaseClass
    {
       public int Id { get; set; }
       public string StringField { get; set; }
       /* Other fields */ 
    }
    [Table("Table1")]
    public class Table1 : BaseClass
    {
    }
 
    [Table("Table2")]
    public class Table2 : BaseClass
    {
    }
 
