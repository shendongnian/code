    [assembly: PreApplicationStartMethod(typeof(MyClassLibrary.Startup), "Start")]
    namespace MyClassLibrary
    {
    	public class Startup
    	{
    		// Automatically will work on startup
    		public static void Start()
    		{
    			  Mapper.Initialize(cfg =>
    			  {
    					Assembly.GetExecutingAssembly().FindAllDerivedTypes<Profile>().ForEach(match =>
    					{
    						cfg.AddProfile(Activator.CreateInstance(match) as Profile);
    					});
    			  });
    		}
    	}
    }
