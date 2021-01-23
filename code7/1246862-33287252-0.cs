    public class Service
    {
    	[Key]
    	public int ServicId { get; set; }
        // I deleted this line
    	public virtual List<ItemService> ItemServices { get; set; }
        // etc...
    }
    
    public class Item
    {
    	[Key]
    	public int ItemId { get; set; }
        
        // I deleted this line too
    	public virtual List<ItemService> ItemServices { get; set; }
        // etc...
    }
