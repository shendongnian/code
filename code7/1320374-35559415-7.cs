    public class EntityConfigiration : DbConfiguration
    {
    	public EntityConfigiration()
    	{
    		this.AddInterceptor(new EfCommandInterceptor());
    	}
    }
