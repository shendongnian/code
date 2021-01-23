    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlWeatherContext : DbContext
    {
        public MySqlWeatherContext() : base("context"){}
        public DbSet<Measurepoint> Measurepoints { get; set; }
    }
