    using (var da = new SqlDataAdapter(cmd))
    {
        da.Fill(user.dt);
        if (user.dt.Rows.Count > 0)
        {
            foreach (DataRow row in user.dt.Rows)
            {
                string name = row.Field<string>(0);
                Library.writeErrorLog(name);
            }
        }
        else
            Library.writeErrorLog("no rows");
    }
