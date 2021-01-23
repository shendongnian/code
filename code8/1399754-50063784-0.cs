    public class Owner 
    {
    	public int? ID { get; set; }
    	public string Name { get; set; }
    }
    
    public class Animal
    {
    	public int? ID { get; set; }
    	public string Name { get; set; }
    	[ForeignKey("Owner")]
    	public int? OwnerID { get; set; }
    	public Owner Owner { get; set; }
    }
