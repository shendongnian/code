    DataTable dt1 = new DataTable();
    dt1.Columns.Add("Name");
    dt1.Rows.Add("Apple");
    dt1.Rows.Add("Banana");
    dt1.Rows.Add("Orange");
     
    DataTable dt2 = new DataTable();
    dt2.Columns.Add("Name");
    dt2.Rows.Add("Apple");
    dt2.Rows.Add("Banana");
     
    List<DataRow> rows_to_remove = new List<DataRow>();
    foreach (DataRow row1 in dt1.Rows)
    {
        foreach (DataRow row2 in dt2.Rows)
        {
            if (row1["Name"].ToString() == row2["Name"].ToString())
            {
                rows_to_remove.Add(row1);
            }
        }
    }
     
    foreach (DataRow row in rows_to_remove)
    {
        dt1.Rows.Remove(row);
        dt1.AcceptChanges();
    }
