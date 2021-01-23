    public partial class MyPage : BasePage
    {
    }
    public class BasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
