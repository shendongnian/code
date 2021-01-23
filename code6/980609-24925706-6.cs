     public partial class Default: System.Web.UI.Page
    {
       string strConn = WebConfigurationManager.ConnectionStrings["ConnectioString"].ConnectionString;
      
       protected void Page_Load(object sender, EventArgs e)
       {
          using(SqlConnection conn = new SqlConnection(strconn)) // This ensures that all resources will be closed and disposed 
        // when the code exits. 
          {
             
          }
        
       }
       // so on
     }
