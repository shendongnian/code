    // This is an example of DbContext class  it implements DbContext
    // If you do not use constructor(s) then the expectation by entity framework
    // will be that your name of your connectionstring in web.config 
    // or app.config is name name as your class  so e.g.  "YourContext",                        
    // otherwise   "Name="YourConnectionString"
    public class YourContext : DbContext
    {
        // constructor as you wish /want 
        public YourContext(string nameOrConnectionString)
			: base(nameOrConnectionString)
		    { }  
        
        // critical mapping 
        public DbSet<someModel> someModel { get; set; }
     
        // critical overide 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // critical key to NOT let your database get dropped or created etc...
            Database.SetInitializer<YourContext>(null);
            // This is an example of mapping model to table 
            // and also showing use of a schema ( dbo  or another )
            modelBuilder.Entity<someModel>().ToTable("someTable", schemaName: "dbo");
						
        }
    }
