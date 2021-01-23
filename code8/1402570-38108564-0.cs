        string queryString = origCommand + customQuery;  //Pull in Query
        string conn = connection.Connection;  //Grab Connection
                         using (OleDbConnection connection1 = new OleDbConnection(conn))
                 {
                     OleDbCommand command = new OleDbCommand(queryString, connection1);
                     command.CommandType = CommandType.Text;
                     try
                     {
                         connection1.Open();
                         OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                         adapter.Fill(oSet);
                                 string firstName = (oSet.Tables[0].Rows[0].ItemArray[9]).ToString();
                         firstName = firstName.Trim();
