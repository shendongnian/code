        DataTable table = new DataTable();
        DataColumn col1 = new DataColumn("clientid");
        DataColumn col2 = new DataColumn("clientname");
        col1.DataType = System.Type.GetType("System.Int32");
        col2.DataType = System.Type.GetType("System.String");
        table.Columns.Add(col1);
        table.Columns.Add(col2);
        DataRow r = table.NewRow();
        r[col1] = 1;
        r[col2] = "client 1";
        table.Rows.Add(r);
        r = table.NewRow();
        r[col1] = 1;
        r[col2] = "client 2";
        table.Rows.Add(r);
        r = table.NewRow();
        r[col1] = 2;
        r[col2] = "client 3";
        table.Rows.Add(r);
        // Create two new data tables
        DataTable dt1 = new DataTable("t1");
        DataTable dt2 = new DataTable("t2");
        // Make the columns of the new tables match the existing table columns
        foreach(DataColumn dc in table.Columns)
        {
            dt1.Columns.Add(new DataColumn(dc.ColumnName, dc.DataType));
            dt2.Columns.Add(new DataColumn(dc.ColumnName, dc.DataType));
        }
        foreach (DataRow row in table.Rows)
        {
            int id = Convert.ToInt32(row["clientid"]);
            if (id == 1)
            {
                DataRow dr = dt1.NewRow();
                dr.SetField("clientid", row["clientid"]);
                dr.SetField("clientname", row["clientname"]);
                dt1.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dt2.NewRow();
                dr.SetField("clientid", row["clientid"]);
                dr.SetField("clientname", row["clientname"]);
                dt2.Rows.Add(dr);
            }
        }
    }
