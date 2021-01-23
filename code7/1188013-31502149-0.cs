    table.PrimaryKey = new DataColumn[] { table.Columns["stationid"] };
    StringBuilder sb = new StringBuilder();
    for (int i = 1000; i <= 9999; i++)
    {
        if (!table.Rows.Contains(i))
            sb.AppendFormat("{0}{1}", Environment.NewLine, i);
    }
