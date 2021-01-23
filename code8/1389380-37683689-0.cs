    class Startup // Can also be in Program or App
    {
        public static void ConfigureDesignTimeServices(IServiceCollection services)
            => services.AddSingleton<EntityTypeWriter, MyEntityTypeWriter>();
    }
