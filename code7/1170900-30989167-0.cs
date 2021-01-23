        conn = new SqlConnection(connString);
        string query = "SELECT * FROM ....";
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        GridView1.DataSource = dt;
        GridView1.DataBind();
