    if (t1 == null || t2 == null) throw new ArgumentNullException("t1 or t2", "Both tables must not be null");
    DataTable t3 = t1.Clone();  // first add columns from table1
    foreach (DataColumn col in t2.Columns)
    {
        string newColumnName = col.ColumnName;
        int colNum = 1;
        while (t3.Columns.Contains(newColumnName))
        {
            newColumnName = string.Format("{0}_{1}", col.ColumnName, ++colNum);
        }
        t3.Columns.Add(newColumnName, col.DataType);
    }
    var mergedRows = t1.AsEnumerable().Zip(t2.AsEnumerable(),
        (r1, r2) => r1.ItemArray.Concat(r2.ItemArray).ToArray());
    foreach (object[] rowFields in mergedRows)
        t3.Rows.Add(rowFields);
       return t3;
    }
