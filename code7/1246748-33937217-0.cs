    using (var conn = new SqlConnection(_connectionString))
    {
        int filesCount = 1;
        int col = 1, row = 1;
        string fileName = String.Empty;
        int count;
        ExcelPackage pck;
        ExcelWorksheet ws;
        using (var cmd = new SqlCommand(string.Format(DataQuery, tableName), conn))
        {
             cmd.CommandType = CommandType.Text;
             cmd.CommandTimeout = 360;
             conn.Open();
             using (SqlDataReader sdr = cmd.ExecuteReader())
             {
                  while (sdr.Read())
                  {
                       if (row == 1)
                       {
                           fileName = string.Format(TargetFile, tableName, filesCount);
                           if (File.Exists(fileName))
                           {
                                File.Delete(fileName);
                           }
                           pck = new ExcelPackage(new FileInfo(fileName));
                           ws = pck.Workbook.Worksheets.Add("RESULTS");
                       }
                       count = sdr.FieldCount; 
                       for (int i = 0; i < count; i++)
                       {
                           var val = sdr.GetValue(i);
                           ws.SetValue(row, col++, val);
                       }
                       row++;
                       col = 1;
                       if (row >= 50000)
                       {
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();
                            ws.Cells[1, 1, 1, count].AutoFilter = true;
                            pck.Save();
                            row = 1;
                            filesCount+
                       }
                   }
              }
              if (row > 1)
              {
                   ws.Cells[ws.Dimension.Address].AutoFitColumns();
                   ws.Cells[1, 1, 1, count].AutoFilter = true;
                   pck.Save();
              }
         }
    }
    conn.Close();
 
