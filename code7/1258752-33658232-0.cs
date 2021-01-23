    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    
    private void BindGrid()
    {
        using (SqlConnection conn = new SqlConnection("your connection string here"))
        using (SqlCommand command = new SqlCommand("SELECT * FROM TestTable", conn))
        {
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
