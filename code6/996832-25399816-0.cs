    public class PageWithShortcuts : System.Web.UI.Page
    {
        // Add JavaScript-outputting functions and other shared functionality here
        private void Page_Load(object sender, System.EventArgs e)
        {
            RegisterStartupScript("mycode", "<script>...</script>");
        }
    }
