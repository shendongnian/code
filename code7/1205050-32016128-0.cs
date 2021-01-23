    protected void BindData()
    {
        using (SqlConnection sqlCon = new SqlConnection(ConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM [Inventory]";
                cmd.Connection = sqlCon;
                sqlCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSourceID = null;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                sqlCon.Close();
            }//end using
        }//end using
    }
