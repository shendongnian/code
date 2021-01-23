            DataTable dt = new DataTable();
            SqlConnection myConn = new SqlConnection("Data Source=SERVER-SQL1;Initial Catalog=OPSystem;Integrated Security=True");
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("spCustomers", myConn);
            myCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.DataBind();
