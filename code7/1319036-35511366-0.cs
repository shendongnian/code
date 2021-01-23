    public class StockItem
    {
       public int Id { get; set; }  // Identity, Key is default by convention so annotation not needed
       public virtual ICollection<StockItemPrintJob> StockItemPrintJobs { get; set; }
    }
    
    public class PrintJob
    {
       public int Id { get; set; }  // Identity, Key is default by convention
       public virtual ICollection<StockItemPrintJob> StockItemPrintJobs { get; set; }
    }
    
    public class StockItemPrintJob
    {
       [Key, Column(Order = 0)]
       public int StockItemId { get; set; }
    
       [Key, Column(Order = 1)]
       public int PrintJobId { get; set; }
    
       public bool IsPrinted { get; set; }
       public virtual StockItem StockItem{ get; set; }
       public virtual PrintJob PrintJob { get; set; }}
    }
