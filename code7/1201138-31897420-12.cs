    namespace WebTester
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            [WebMethod]
            public static string ProcessIT(string name, string address)
            {
                return WebUserControl1.ProcessIT(name, address);
            }
        }
    }
