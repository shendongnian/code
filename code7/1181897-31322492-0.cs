    public class MainActivity : Activity, IEventListener
    {
    	private Endpoint endpoint; // could possibly be readonly
    	
    	public MainActivity()
    	{
    		endpoint = Endpoint.newInstance(true, this);
    	}
    }
