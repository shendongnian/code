    class Startup
    {
        public static void ConfigureDesignTimeServices(IServiceCollection services)
            => services.AddSingleton<EntityTypeWriter, MyEntityTypeWriter>();
    }
