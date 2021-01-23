    using System.Web;
    using System.Web.UI;
    
    [assembly: PreApplicationStartMethod(typeof(MyAssembly.MyHttpApplication), nameof(MyAssembly.MyHttpApplication.Application_Register)]
    namespace MyAssembly
    {
    	public class MyHttpApplication : HttpApplication
    	{
    		public static void Application_Register()
    		{
    			PageParser.DefaultApplicationBaseType = typeof(MyHttpApplication);
    		}
    		
    		protected void Application_Start()
    		{
    			// TODO: Your application startup magic :)
    		}
    		
    		protected void Application_BeginRequest(object sender, EventArgs e)
    		{
    			// TODO: 
    		}
    	}
    }
