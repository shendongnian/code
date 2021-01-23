      foreach (DataColumn col in dataTable.Columns)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                      var x=row[col.ColumnName].ToString();
                      if (string.IsNullOrEmpty(x))
                      {
                          var colName = col.ColumnName.ToString();
                          row["remarks"] = string.Format("{0} is required", colName);
                      }
    
                    }
                } 
