    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtInputID.Attributes.Add("onblur", "Validate();");
        }
    }
