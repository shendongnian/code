    public class BasePage : System.Web.UI.Page {
        protected virtual void Page_Load(object sender, EventArgs e) {
            if (Session["redirect_message"] != null) {
                ClientScript.RegisterStartupScript(GetType(), "redirect_message",
                    String.Format("alert('{0}');", (string)Session["redirect_message"]),
                    true);
                Session.Remove("redirect_message");
            }
        }
    }
