    public class DataSourceFactory
    {
    	public static IDataSource CreateDataSource()
    	{
    		if (/* are we using real data source */)
    		{
    			return new RealDatabase();
    		}
    		else
    		{
    			return new MoqDataSource();
    		}
    	}
    }
