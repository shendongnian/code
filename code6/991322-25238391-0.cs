    public partial class test: System.Web.UI.Page
    {
        private String msg;
        protected void OnPreRender(object sender, EventArgs e)
        {
            status.Text = msg;
        }
    
        protected void action(object sender, EventArgs e)
        {
            msg = "Hello world!";
        }
    }
