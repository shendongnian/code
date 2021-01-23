    public partial class faq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        [WebMethod]
        public static string DoAJAX(string foo)
        {
            return foo;
        }
    }
