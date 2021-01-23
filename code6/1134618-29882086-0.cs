    public class ItemProperties
    {
    	public string Item { get; set; }
    	public string Description { get; set; }
    	public int Quantity { get; set; }
    	public int UnitPrice { get; set; }
    	public int Tax { get; set; }
    
    	public int TotalPay { get { return Quantity * UnitPrice; } set; }
    
    }
 
