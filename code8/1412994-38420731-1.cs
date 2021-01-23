    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            try {
                long itemid = -1;
                string req = Request.QueryString["id"];
                if (long.TryParse(req, out itemid)) {
                    litId.Text = itemid.ToString();
                }
                else {
                    litId.Text = "Couldn't parse!";
                }
            }
            catch (Exception ex){
                litId.Text = "An error occured:" + ex.Message;
            }
        }
    }
