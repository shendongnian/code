       StringBuilder output = new StringBuilder();
       foreach (DataRow rows in results.Tables[0].Rows)
       {
           foreach (DataColumn col in results.Tables[0].Columns)
           {
              output.AppendFormat("{0} ", rows[col]);
           }
           output.AppendLine();
       }
