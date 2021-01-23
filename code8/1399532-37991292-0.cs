    using (SqlCommand cmd = conn.CreateCommand())
            {
                SqlCommand com = new SqlCommand("Select * from Table2", conn);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dt = new DataSet();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
