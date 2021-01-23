    public class HibernateConnectionProvider : NHibernate.Connection.DriverConnectionProvider
    {
    	public static IProvider<string> ConnectionStringProvider { private get; set; }
    
    	protected override string ConnectionString
    	{
    		get { return ConnectionStringProvider.ProvideValue(); }
    	}
    }
