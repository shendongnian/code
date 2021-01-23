     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGridView();
        }
    }
        public void FillGridView()
    {
        try
        {
    string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            string selectSQL = "SELECT * FROM YourTableName";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "YourTableName");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch
        {
            Response.Write("<script> alert('Connection error') </script>");
        }
    }
