    using System;
    using System.Web.UI;
    using System.Web.Security;
    namespace User_Login_CS
    {
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
            SqlDataSource3.InsertParameters["SB"].DefaultValue = Page.User.Identity.Name;
               
    }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource3.Insert();
        }
    }
    }
