    public partial class YourDataMigration : DbMigration 
    {
        public override void Up() 
        {
            // Importing from CSV
            using(db = new FooDbContext())
                ImportUtil.ImportFoos(db, "initial_foo_data.csv"));
    	}
    
    	public override void Down()
    	{
            // Nothing!
    	}
    
    }
