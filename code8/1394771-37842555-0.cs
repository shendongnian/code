    public partial class SqlDataSourceExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlDataSource1.Insert();
        }
    }
