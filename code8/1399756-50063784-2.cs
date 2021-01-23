    public class Owner 
    {
    	public int? ID { get; set; }
    	public string Name { get; set; }
    }
    
    public class Animal
    {
    	public int? ID { get; set; }
    	public string Name { get; set; }
    	public int? OwnerID { get; set; }
    	[ForeignKey("OwnerID")]
    	public Owner Owner { get; set; }
    }
