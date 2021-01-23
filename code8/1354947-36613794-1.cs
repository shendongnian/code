    public partial class ListUsers : System.Web.UI.Page{
        private CurrentUserStructure UserInfo
        {
            get
            {
                // Read the object from session store
                return (CurrentUserStructure) HttpContext.Current.Session["currentuserinfo"];
            }
        }
    }
