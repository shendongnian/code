    using System;
    public class Program {
    	public class IdentityDbContext {
    		public DbContextOptions Options { get; set; }
    		public IdentityDbContext(DbContextOptions options){
    			this.Options = options;
    		}
    	}
    	
    	public class DbContextOptions {
    		public string Config { get; set; }
    		
    		public DbContextOptions(string config){
    			this.Config = config;
    		}
    		
    		public static implicit operator DbContextOptions(string config)	{
    			return new DbContextOptions(config);
    		}
    	}
    	
    	public static void Main()
    	{
    		IdentityDbContext f = new IdentityDbContext(new DbContextOptions("test")); //it's ok
    		Console.WriteLine(f.Options.Config);
    		
    		IdentityDbContext f2 = new IdentityDbContext("testWithImplicit");
    		Console.WriteLine(f2.Options.Config);
    	}
    }
