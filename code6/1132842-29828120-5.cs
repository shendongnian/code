    for (int i = 0; i < 1000; i++)
    {
        var con = new SqlConnection(Properties.Settings.Default.ConnectionString);
        con.Open();
        var cmd = new SqlCommand("Select 1", con);
        var rd = cmd.ExecuteReader();
        while (rd.Read())
            Console.WriteLine("{0}) {1}", i, rd.GetInt32(0));
    }
