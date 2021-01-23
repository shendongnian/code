     // Normally I would make the point that queries should be parameterized rather
     // than built up in code, but since you can't parameterize the name of
     // a table, in this case you need to construct the query text.
     string queryText = [however you build your query]
     using(SqlConnection conn = new SqlConnection("your connection string"))
     {         
         using(SqlCommand cmd = new SqlCommand(queryText, conn))
         {
             conn.Open();
             using(var dr = cmd.ExecuteReader())
             {
                 using(var sw = new StreamWriter("your output file name"))
                 {
                     while(dr.Read())
                     {
                         for(int i = 0; i< dr.FieldCount; i++)
                         {
                             // Every column but the first needs a preceding comma.
                             if(i > 0)
                             {
                                 sw.Write(",");
                             }
                             // You will probably want to customize this according to your requirements.
                             if(!dr.IsDBNull(i))
                             {
                                 if(dr.GetFieldType() == typeof(string))
                                 {
                                      sw.Write("\"{0}\"", dr.GetString(i));
                                 }
                                 else
                                 {
                                      sw.Write("{0}", dr.GetValue(i));
                                 }
                             }
                             // If you want nulls to appear as "Null", use this clause; otherwise, skip it.
                             else 
                             {
                                 sw.Write("\"Null\"");
                             }
                         }  // for i
                         // Add a line feed.
                         sw.WriteLine();
                     }  //while dr
                 }  // using sw   
             }  // using dr
         }  // using cmd
     } // using conn
