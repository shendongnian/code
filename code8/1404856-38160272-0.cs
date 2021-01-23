    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            BindData();
    }
    private void BindData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        using(var con = new SqlConnection(connectionString))
        {
            using(var command = new SqlCommand("SELECT ID,City FROM Cities",con))
            {
                using(var adapter = new SqlDataAdapter(command))
                {
                    con.Open();
                    var table = new DataTable();
                    adapter.Fill(table);
                    gvData.DataSource = table;
                    gvData.DataBind();
                    con.Close();
                }
            }
        }
    }
