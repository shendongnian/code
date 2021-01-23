    using (var con = new SqlConnection("connection-string"))
    using (var cmd = new SqlCommand("storedprocedurename", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        // parameters here...
        con.Open();
        using (var rd = cmd.ExecuteReader())
        {
            if (rd.Read())
            {
                string column = rd.GetName(0); // first column
                int value = rd.GetInt16(0);    // or rd.GetInt32(0)
            }
        }
    }
