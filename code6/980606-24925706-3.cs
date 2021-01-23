    public partial class Default: System.Web.UI.Page
    {
       static string strConn = WebConfigurationManager.ConnectionStrings["ConnectioString"].ConnectionString;
       SqlConnection conn = new SqlConnection(strconn);
       protected void Page_Load(object sender, EventArgs e)
       {
         // bla bla bla
       }
       // so on
     }
