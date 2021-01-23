    DataTable dt = new DataTable();
    dt.Columns.Add("ID", typeof(System.Int32));
    dt.Columns["ID"].AutoIncrement = true;
    dt.Columns["ID"].AutoIncrementSeed = 1;
    dt.Columns.Add("Amount", typeof(System.Int32));
    dt.PrimaryKey = new DataColumn[] {dt.Columns["ID"]};
    
    dt.Rows.Add(null, "10");
    dt.Rows.Add(null, "20");
    
    DataRow[] found = dt.Select("ID=1");
    if(found.Length == 1)
    {
        int value = found[0].Field<int>("Amount");
        found[0].SetField("Amount", value + 10);
    }
