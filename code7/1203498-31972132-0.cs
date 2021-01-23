    public class BasePage: System.Web.UI.Page
    {
        public BasePage()
        {
            this.PreInit += AuthenticationFilter;
        }
    
        public void AuthenticationFilter(object sender, EventArgs e)
        {
            if(!User.IsAuthenticated)
            {
                Response.Redirect("~/User/Login");
            }
        } 
    }
