    ds.Tables[3].Columns[2].ReadOnly = false;
    while (reader.Read())
    {
        foreach (DataRow item in ds.Tables[3].Rows)
        {
            if ((Guid)item[3] == reader.GetGuid(0))
            {
                item[2] = reader.GetInt32(1);
            }
        }
    } 
