    public partial class WebForm1 : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // get all plugins on the page
            var plugins = Controls.OfType<MyPluginBase>();
        }
    }
