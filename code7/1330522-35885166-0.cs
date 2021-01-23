    [Table("ProductOrService")]
    public abstract class ProductOrService
    {
    	public int Id { get; set; }
    	public DateTime AddedToCartAt { get; set; }
    	public string Name { get; set; }
    	public decimal Price { get; set; }
    }
    
    [Table("ProductOrService")]
    public class Level1Product : ProductOrService
    {
    	public string Owner { get; set; }
    }
    
    [Table("ProductOrService")]
    public class Level1Service : ProductOrService
    {
    	public string Activator { get; set; }
    }
    
    [Table("ProductOrService")]
    public abstract class Level2ProductOrService : ProductOrService
    {
    	public string SomeProp { get; set; }
    }
    
    [Table("ProductOrService")]
    public class Level2Product : Level2ProductOrService
    {
    	public DateTime IssuedAt { get; set; }
    }
    
    [Table("ProductOrService")]
    public class Level2Service : Level2ProductOrService
    {
    	public DateTime ExpiresAt { get; set; }
    }
