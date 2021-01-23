        public class SalesOrder 
        {
        	public int Id {get; set;}
        	public DateTime OrderDate {get; set;}
        	// Nav property
        	public ICollection<SalesOrderDetail> OrderDetails { get; set; }
        }
        
        public class SalesOrderDetail
        {
        	public int Id {get; set;}
        	// Foreign key property
        	public int SalesOrderId {get; set;}
        	// Nav property
        	public SalesOrder SalesOrder {get; set;}
        }
    
