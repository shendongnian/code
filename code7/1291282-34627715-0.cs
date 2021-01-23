    public class Global : System.Web.HttpApplication
    {
       public static object MyObject { get; private set; }
       protected void Application_Start(object sender, EventArgs e)
        {
            MyObject = new object();
        }
    }
