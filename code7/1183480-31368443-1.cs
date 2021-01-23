    DataColumn col = mesakem.Tables["fullname"].Columns.Add("Id");
    col.SetOrdinal(0);
    foreach (DataRow row in mesakem.Tables["fullname"].Rows)
    {
        foreach (oved o in ovdimlist)
        {
            if (o.name == row["Name"].ToString())
                row["Id"] = o.id;
        }
    }
