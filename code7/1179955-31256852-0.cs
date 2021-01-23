     Dictionary<string, string> columnMap = new Dictionary<string, string>();
     using (var conn = new SqlConnection(...))
     using (var cmd = new SqlCommand("SELECT HeaderName, ColumnName FROM Columns"))
     using (var dr = cmd.ExecuteReader()) 
     {
         while (dr.Read()) 
         {
            columnMap.Add(dr.GetString(0), dr.GetString(1));
         }
     }
