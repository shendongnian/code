    foreach (DataRow dr in dt.Rows)
    {
      row = new Dictionary<string, object>();
      foreach (DataColumn col in dt.Columns)
        {
        row.Add(col.ColumnName, dr[col]);
        }
       rows.Add(row);
    }
    context.Response.Write(serializer.Serialize(new { data= rows }).ToString());
