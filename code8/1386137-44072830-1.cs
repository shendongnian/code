    public class SomeClass
    {
    	public SomeClass(IConfigurationRoot configuration) 
    	{
    		NHibernateUnitOfWork.Init(Configuration["ConnectionStrings:OracleConnection"]);
    	}
    }
