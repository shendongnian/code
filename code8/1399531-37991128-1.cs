    using (SqlCommand cmd = conn.CreateCommand())
            {
                SqlCommand com = new SqlCommand("Select * from Table2", conn);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
