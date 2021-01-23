    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        if(reader.HasRows)
        {
            user.dt.Load(reader); // all records added
            foreach(DataRow row in user.dt.Rows)
            {
                string name = row.Field<string>(0);
                Library.writeErrorLog(name);
            }
        }
        else
            Library.writeErrorLog("no rows");
    }
