    using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    using (SqlCommand comm = new SqlCommand("SELECT * FROM TUsers", conn))
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
        DataSet ds = new DataSet();
        dataAdapter.Fill(ds, "Users");
        lvUsers.DataSource = ds.Tables[0];
        lvUsers.DataBind();
    }
