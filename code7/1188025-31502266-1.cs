    foreach (DataColumn col in result.Table[0].Columns)
    {
         foreach (DataRow row in result.Table[0].Rows)
         {
              Console.WriteLine(row[col.ColumnName].ToString());           
         }
    } 
