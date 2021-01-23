        using (var con = new SqlCeConnection())
        {
            con.ConnectionString = @"Data Source = |DataDirectory|\Database\DB.sdf;Persist Security Info=False";
            var cmd = new SqlCeCommand("SELECT * FROM TEST", con);
            con.Open();
            var data = new DataTable("whatever");
            data.Load(cmd.ExecuteReader());
            con.Close();
        }
