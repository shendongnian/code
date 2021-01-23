    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Scheduler.Start();
        }
    
        void Application_End(object sender, EventArgs e)
        {
            Scheduler.Stop();
        }
    }
