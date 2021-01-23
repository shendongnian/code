	/// <summary>
	/// The <see cref="IEntityFrameworkModelBuilder"/> implementation of a building model on the base of <see cref="DbContext"/> instance calling its <see cref="DbContext.OnModelCreating"/> protected method.
	/// </summary>
	/// <seealso cref="DbContextOnModelCreatingAdaptingModelBuilder"/>
	/// <seealso cref="EntityFrameworkModelBuilderComposition"/>
	public class DbContextOnModelCreatingAdaptingModelBuilder : IEntityFrameworkModelBuilder
	{
		private readonly Func<DbContext> _dbContextFactoryMethod;
		/// <inheritdoc />
		public DbContextOnModelCreatingAdaptingModelBuilder(Func<DbContext> dbContextFactoryMethod)
		{
			_dbContextFactoryMethod = dbContextFactoryMethod;
		}
		/// <inheritdoc />
		public void BuildModel(ModelBuilder modelBuilder)
		{
			using (var dbContext = _dbContextFactoryMethod())
			{
				MethodInfo onModelCreating = dbContext.GetType().GetMethod("OnModelCreating", BindingFlags.NonPublic | BindingFlags.Instance);
				onModelCreating.Invoke(dbContext, new object[] {modelBuilder});
			}
		}
	}
