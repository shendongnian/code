    public partial class Home : System.Web.UI.Page
    {
        DbBroker dbb = new DbBroker();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label3.Text = Session["Username"].ToString();
                dbb.executeQuery(); //populate list.
                dbb.getArr(); //convert to string and update textbox
            } 
        }
    }
