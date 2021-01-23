    public partial class FirstPage : Page {
        private bool redirected = false;
        protected void Page_PreInit(object sender, EventArgs e) {
            if (redirect_condition_is_true) {
                Session["redirect_message"] = "I've sent you (nicely this time) to OtherPage.aspx";
                MasterPageFile = "~/Redirect.Master";
                redirected = true;
                Response.Redirect("~/OtherPage.aspx", false); // don't use Response.End()
                Context.Application.CompleteRequest();
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            // for all Page events we're processing, start with:
            if (redirected) {
                return;
            }
        }
    }
