    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ""; //preserve your connection string
        SqlConnection con = new SqlConnection(connectionString);
        string selectSQL = String.Format("SELECT * FROM V_QUESTIONS WHERE Id = @ID"); //
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        cmd.Parameters.Add("@ID", SqlDbType.Int); //
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Question");
        Submit_Details.DataSource = ds;
        Submit_Details.DataBind();
    }
