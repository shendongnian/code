     using (SqlConnection con = new SqlConnection(strConnString))
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "select top 10 * from Customers";
            cmd.Connection = con;
            con.Open();
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();
        }
    }
