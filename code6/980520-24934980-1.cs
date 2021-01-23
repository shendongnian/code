    	public class SigoContext : DbContext {
    		public SigoContext() : base("SigoMain") {}
    			public DbSet<TopMenu> TopMenu{ get; set; }
    		}
    	}
