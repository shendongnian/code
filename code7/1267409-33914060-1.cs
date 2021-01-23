    int? value = null;
    using (var con = new SqlConnection("connection string"))
    using(var cmd = new SqlCommand("Sql-Query", con))
    {
        con.Open();
        int row = 0;
        using (var rd = cmd.ExecuteReader())
        {
            while (rd.Read())
            {
                row++;
                if (row == 2)
                    value = rd.GetInt32(1);
            }
        }
    }
