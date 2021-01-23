    public partial class WineKeeper : System.Web.UI.MasterPage {
	    private BLSecurity BLSecurity = new BLSecurity();
        protected void Page_Load(object sender, EventArgs e) {
            BLSecurity.Gebruiker = (wk_Gebruiker)Session["gebruiker"];
            SomeFunction();
        }
    }
