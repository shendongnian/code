    DataTable dt = new DataTable();
    dt.Columns.Add("ID", typeof(System.String));
    dt.Columns.Add("Amount", typeof(System.Int32));
    dt.PrimaryKey = new DataColumn[] {dt.Columns["ID"]};
    
    dt.Rows.Add("A", "10");
    dt.Rows.Add("B", "20");
    
    DataRow[] found = dt.Select("ID='A'");
    if(found.Length == 1)
    {
        int value = found[0].Field<int>("Amount");
        found[0].SetField("Amount", value + 10);
    }
