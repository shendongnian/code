    DataColumn newColumn = new System.Data.DataColumn("pvar", typeof(System.String));
    table.Columns.Add(newColumn);
    foreach (DataRow dr in table.Rows)
    {
        dr["pvar"] = dr["Column2"].ToString() + "|" + dr["Column3"].ToString();
    }
