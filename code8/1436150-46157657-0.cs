    foreach (DataColumn column in dt.Columns)
    {
        if (dt.Columns.IndexOf(column) != 0)
        {
            html.Append("<td>");
            html.Append(row[column.ColumnName]);
            html.Append("</td>");
         }
      }
