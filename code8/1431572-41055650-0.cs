	/// <summary>
	/// Formalization of entity framework DbContext model creation <see cref="DbContext.OnModelCreating"/>
	/// </summary>
	/// <remarks>
	/// The reason for this explicit interface of the <see cref="DbContext.OnModelCreating"/> is to make compositions of several model builders into one
	/// </remarks>
	public interface IEntityFrameworkModelBuilder
	{
		void BuildModel(ModelBuilder modelBuilder);
	}
    public abstract class DbContextBase : DbContext
    {
    
        protected DbContextBase(DbContextOptions options, IEntityFrameworkModelBuilder modelBuilder) : base(options)
    	{
    		_modelBuilder = modelBuilder;
    	}
    
        public virtual IEntityFrameworkModelBuilder ModelBuilder
		{
			get { return _modelBuilder ?? (_modelBuilder = new DefaultSchemaEntityFrameworkModelBuilder("dbo")); }
			protected set { _modelBuilder = value; }
		}
    	protected override void OnModelCreating(ModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    		ModelBuilder.BuildModel(modelBuilder);
    	}
    }
