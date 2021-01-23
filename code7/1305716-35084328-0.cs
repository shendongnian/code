    public partial class SitesEntities
    {
        public SitesEntities()
            : base(GetConnectionString())
        {
        }
        public static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("my_env_varible");
        }
    }
