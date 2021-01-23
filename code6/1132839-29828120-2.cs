    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    {
        con.Open();
        for (int i = 0; i < 1000; i++)
        {
            var cmd = new SqlCommand("Select 1", con);
            using (var rd = cmd.ExecuteReader())
                while (rd.Read())
                    Console.WriteLine("{0}) {1}", i, rd.GetInt32(0));
        }
    }// no need to close it with the using statement
