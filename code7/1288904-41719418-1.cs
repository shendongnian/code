    public enum Shape
    {
    	Square,
    	Round
    }
    
    public class Foo
    {
    	public int Id { get; set; }
    	public Shape Shape { get; set; }
    }
    public class MyDbContext : DbContext
	{
		public DbSet<Foo> Foos { get; set; }
	}
    using(var context = new MyDbContext())
    {
        var enumToLookup = new EnumToLookup
        {
            TableNamePrefix = string.Empty,
            NameFieldLength = 50,
            UseTransaction = true
        };
        enumToLookup.Apply(context);
    }
