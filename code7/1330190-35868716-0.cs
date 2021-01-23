    public void Select()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string cs = "server=(local);database=DB_Taxi;trusted_connection=yes;";
            con.ConnectionString = cs;
            con.Open();
            cmd.Connection = con;
            da.SelectCommand = cmd;
            cmd.CommandText = "SELECT * FROM Tbl_Driver";
            da.Fill(dt);
            con.Close();
           //clearing the datasource
            grid.DataSource = null;
            //set the datasource
            grid.DataSource = dt;
        }
