    using (reader = new SqlCommand(query, conn).ExecuteReader())
    {
         for (int i = 0; i < reader.FieldCount; i++)
         {
               sb.Append(reader.GetName(i));
               if( i < (reader.FieldCount -1)
                   sb.Append(strDelimiter);
         }
         sb.Append(Environment.NewLine);
         if (reader.HasRows)
         {
              Object[] items = new Object[reader.FieldCount];
              while (reader.Read())
              {
                    reader.GetValues(items);
                    sb.Append(string.Join(strDelimiter,item.ToString()));
                    sb.Append(Environment.NewLine);
              }
          }
     }
