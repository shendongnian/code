    using (OleDbConnection conn = new OleDbConnection("yourconnectionString"))
      {
         conn.Open();
         using (OleDbCommand  cmd =new OleDbCommand("your query text",  conn))
           {
             // execute your command
           }
     }
