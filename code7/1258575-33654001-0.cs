                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString);
        string SQL = "SELECT * FROM [Table];";
        SqlDataAdapter adapter = new SqlDataAdapter(SQL, conn);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
