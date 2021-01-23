    public class MyDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<EntityTypeWriter, MyEntityTypeWriter>();
            serviceCollection.AddSingleton<DbContextWriter, MybContextWriter>();
        }
    }
