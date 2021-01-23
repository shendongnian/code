    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Thread backGroundProcess = new Thread(BoucleInfini);
            backGroundProcess.Start();
        }
    }
