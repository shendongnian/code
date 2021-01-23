    ds = new DataSet();
    using (SqlDataAdapter da = new SqlDataAdapter(sql, compareConnString))
    {
        da.Fill(ds);
    }
    if (ds.Tables[0].Rows.Count > 0)
    {
        int rowCount = ds.Tables[0].Rows.Count;
        int rowsRemaining = rowCount;
        for (int i = 0; i < rowCount; i+=2)
        {
            if (!(rowsRemaining == 1))
            {
                var row1 = ds.Tables[0].Rows[i];
                var row2 = ds.Tables[0].Rows[i + 1];
                if (row1[1].ToString() == row2[1].ToString())
                {
                    foreach (DataColumn col in ds.Tables[0].Columns)
                    {
                        if (col.ColumnName != "CompareDiff")
                        {
                            if (row1[col].ToString() != row2[col].ToString())
                            {
                                crs.ColumnsChanged.Add(col.ColumnName);
                            }
                         }
                      }
                  }
              }
              rowsRemaining -= 2;
          }
