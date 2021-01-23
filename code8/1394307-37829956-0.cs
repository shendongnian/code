    public partial class DisplayGridViewWithPaging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.GetData();
            }
        }
        private void GetData()
        {
            DataTable table = this.GetEmails();
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
        private DataTable GetEmails()
        {
            var table = new DataTable();
            //Connection for the database from the Web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("SELECT EmailType, EmailAddress FROM EmailNotifications", connection))
                {
                    using (var a = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        a.Fill(table);
                        connection.Close();
                    }
                }
            }
            return table;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.GetData();
        }
    }
