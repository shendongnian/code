    public class CoolMvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            //check here if this exception is an unauthorized access error, if so
            Server.ClearError();
            Response.Redirect("/not_loggedin");
        }
    }
