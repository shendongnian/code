    public class TestDbContext : DbContext
    	{
    		public IDbSet<ProductOrService> ProductsOrServices { get; set; }
    		public IDbSet<Level2ProductOrService> Level2ProductsOrServices { get; set; }
    		public IDbSet<Level1Product> Level1Products { get; set; }
    		public IDbSet<Level2Service> Level2Services { get; set; }
    	}
