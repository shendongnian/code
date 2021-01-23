    public class MvcApplication : CustomHttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            MenuItems = this.LoadMenuItems();
        }
    }
