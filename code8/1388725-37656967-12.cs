    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        if(reader.HasRows)
        {
            while (reader.Read())
            {
                string name = reader.GetString(0);
                user.dt.Rows.Add(name);
                Library.writeErrorLog(name);
            }
        }
        else
            Library.writeErrorLog("no rows");
    }
