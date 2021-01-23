    public partial class PagingAndSearchingInGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetData();
        }
    
        private void GetData()
        {
            string emailAddress = txtEmailAddress.Text;
            DataTable table = !Page.IsPostBack ? GetEmails() : GetEmails(emailAddress);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    
        private DataTable GetEmails(string emailAddress = "%")
        {
            var table = new DataTable();
    
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("SELECT EmailType, EmailAddress FROM EmailNotifications WHERE EmailAddress LIKE @EmailAddressParam + '%'", connection))
                {
                    command.Parameters.AddWithValue("@EmailAddressParam", emailAddress);
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
