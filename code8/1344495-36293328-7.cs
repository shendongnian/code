         DataTable B = new DataTable();
         for (int i = 0; i < A.Rows.Count; i++)
         {
              foreach (DataColumn col in A.Columns)
              {
                    if (col.DataType == typeof(DateTime))
                         B.Columns.Add(col.ColumnName);
              }
              B.ImportRow(A.Rows[i]);
         }
         foreach (DataRow row in B.Rows)
         {
              foreach (DataColumn col in B.Columns)
              {
                   //Console.WriteLine("Before {0}:",row[col.ColumnName]);
                   row[col.ColumnName] = DateTime.Parse(row[col.ColumnName].ToString()).ToString("dd/MM/yyyy");
                   //Console.WriteLine("After {0}:", row[col.ColumnName]);
              }
         }
