    public interface IDbProviderFactories
    {
        DbProviderFactory GetFactory(string name);
    }
    public class MyDbProviderFactories : IDbProviderFactories
    {
        public DbProviderFactory GetFactory(string name)
        {
            return DbProviderFactories.GetFactory(name);
        }
    }
