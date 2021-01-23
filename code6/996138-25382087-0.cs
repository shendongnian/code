    public class Global : System.Web.HttpApplication
    {
            void RegisterRoutes(RouteCollection routes)
            {
                routes.MapPageRoute("InteriorServices", "InteriorServices", "~/InteriorServices.aspx");
            }
            protected void Application_Start(object sender, EventArgs e)
            {
                RegisterRoutes(RouteTable.Routes);
            }
     }
