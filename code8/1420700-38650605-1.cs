            protected void bind()
        {
            using (SqlConnection con = new SqlConnection("Connection string"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tableName", con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                con.Close();
            }
        }
