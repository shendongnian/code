    public partial class Default : System.Web.UI.Page // Your inherits name will come here
    {
       SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectioString"].ConnectionString);
       protected void Page_Load(object sender, EventArgs e)
       {
         // bla bla bla
       }
       // so on
     }
