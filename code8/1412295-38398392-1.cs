    public class Parent
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    
    	internal ICollection<Child> children;
    	protected virtual ICollection<Child> Children { get { return children; } set { children = value; } }
    	internal ICollection<Child> GetChildren() => Children;
    	internal static Expression<Func<Parent, ICollection<Child>>> ChildrenSelector => p => p.Children;
    }
    
    public class Child
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    
    	internal Parent parent;
    	protected virtual Parent Parent { get { return parent; } set { parent = value; } }
    	internal Parent GetParent() => Parent;
    	internal static Expression<Func<Child, Parent>> ParentSelector => c => c.Parent;
    }
    
    public class MyDbContext : DbContext
    {
    	public DbSet<Parent> Parents { get; set; }
    	public DbSet<Child> Children { get; set; }
    
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Entity<Parent>()
    			.HasMany(Parent.ChildrenSelector)
    			.WithRequired(Child.ParentSelector)
    			.Map(a => a.MapKey("ParentId"));
    
    		base.OnModelCreating(modelBuilder);
    	}
    }
