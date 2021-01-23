    public interface IDbProviderFactories
    {
        public DbProviderFactory GetFactory(string name);
    }
    public class MyDbProviderFactories
    {
        public DbProviderFactory GetFactory(string name)
        {
            return DbProviderFactories.GetFactory(name);
        }
    }
