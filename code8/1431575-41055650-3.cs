    /// <summary>
    /// The composition of <see cref="IEntityFrameworkModelBuilder"/> used to construct <see cref="DbContext"/> model creation from several modules (tests).
    /// </summary>
    /// <seealso cref="DbContextOnModelCreatingAdaptingModelBuilder"/>
    public class EntityFrameworkModelBuilderComposition : IEntityFrameworkModelBuilder, IList<IEntityFrameworkModelBuilder>
    {
        private readonly IList<IEntityFrameworkModelBuilder> _builders;
    
    	public EntityFrameworkModelBuilderComposition() : this(new IEntityFrameworkModelBuilder[0])
    	{}
    
    	public EntityFrameworkModelBuilderComposition(params IEntityFrameworkModelBuilder[] builders)
    	{
    		_builders = new List<IEntityFrameworkModelBuilder>(builders);
    	}
    
    	/// <summary>
    	/// Constructor to take list of builders as underlaying list so it is initialized with these builders and sharing the same reference.
    	/// </summary>
    	/// <param name="builders"></param>
    	public EntityFrameworkModelBuilderComposition(IList<IEntityFrameworkModelBuilder> builders)
    	{
    		_builders = builders ?? new List<IEntityFrameworkModelBuilder>();
    	}
    	
    	public virtual void BuildModel(ModelBuilder modelBuilder)
    	{
    		foreach (var b in _builders)
    		{
    			b.BuildModel(modelBuilder);
    		}
    	}
    }
