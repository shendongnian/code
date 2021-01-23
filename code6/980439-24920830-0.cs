    foreach (DataTable table in sql_ds.Tables)
    {
        foreach (DataRow row in table.Rows)
        {
            if (row.Field<string>["ROW_NAME"].ToString() == stringLumber)
                {
                    //Lets do something.
                }
        }
    }
