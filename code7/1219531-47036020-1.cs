    public class MyDbConfiguration : DbConfiguration
    {
    	public MyDbConfiguration()
    	{
    		SetDefaultHistoryContext((connection, defaultSchema) => new HistoryDbContext(connection, defaultSchema));
    	}
    }
