    [DbContext(typeof(BloggingContext))]
    [Migration("151205_01")]
    public class InitialMigration : Migration
    {
    	protected override void Up(MigrationBuilder migrationBuilder) 
        {
    		// create table, add columns / keys etc.
    	}
    
    	protected override void Down(MigrationBuilder migrationBuilder)
    	{
    		// opposite of "Up", ie. drop table
    	}
    
    	protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            // can remain blank, not sure what its used for
        }
    }
