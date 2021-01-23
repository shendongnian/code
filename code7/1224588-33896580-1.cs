	public class Db : DbContext
	{
		. . .
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var modelsProject = Assembly.GetExecutingAssembly();
			B9DbExtender.New().Extend(modelBuilder, modelsProject);
