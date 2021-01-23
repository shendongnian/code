    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", @"your_path");
        } 
	...
	}
