    [MyCustomAuthorize] // any page with this attribute will first check if they are loggged in
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
