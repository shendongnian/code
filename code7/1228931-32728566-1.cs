	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			Application["OpenSessionCount"] = 0;
		}
		protected void Session_Start(Object sender, EventArgs e)
		{
			Application.Lock();
			
			// Store something every time to ensure the Session object is allocated.
			HttpContext.Current.Session["dummy"] = "Foo";
			Application["OpenSessionCount"] = (int)Application["OpenSessionCount"] + 1;
			Application.UnLock();
			/* Set other Session["foo"] = bar data */
		}
		protected void Session_End(Object sender, EventArgs e)
		{
			Application.Lock();
			Application["OpenSessionCount"] = (int)Application["OpenSessionCount"] - 1;
			Application.UnLock();
		}
	}
