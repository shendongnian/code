    protected void Page_Load(object sender, EventArgs e)
    {
        this.BindData();
    }
    private void BindData()
    {
        string connString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        var table = new DataTable();
        using(var connection = new SqlConnection(connString))
        {
            using(var command = new SqlCommand("SELECT Name,Image FROM Colour",connection))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Close();
            }
        }
        GridView2.DataSource = table;
        GridView2.DataBind();
    }
