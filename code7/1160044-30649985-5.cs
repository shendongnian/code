    public class MyBase : System.Web.UI.Page
    {
        users user
        {
            get
            {
                return Session["new"] as users;
            }
            set
            {
                Session["new"] = value;
            }
        }
    }
