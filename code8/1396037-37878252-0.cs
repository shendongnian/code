    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            this.GetData();
    }
    private void GetData()
    {
        var table = new DataTable();
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        using (var connection = new SqlConnection(connectionString))
        {
            using (var command = new SqlCommand("SELECT ID, City FROM Cities", connection))
            {
                using (var a = new SqlDataAdapter(command))
                {
                    connection.Open();
                    a.Fill(table);
                    connection.Close();
                }
            }
        }
       GridView1.DataSource = table;
       GridView1.DataBind();
    }
