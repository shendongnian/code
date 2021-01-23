    SqlCommand cmd = new SqlCommand(query, connection);
                                  //^^^ here you use insert query
    cmd.Connection = conn;
    conn.Open();
    cmd.CommandText = "SELECT MAX(EmpID) FROM EmpInfo"; // But here you change it for a SELECT?
   
    // Then you execeute a DataReader but you close it before save the result.
    SqlDataReader rdr = cmd.ExecuteReader();
    rdr.Close();
    //Then create the insert command again
    SqlCommand commad = new SqlCommand(query, cmd.Connection);
  
    ....
     
    // clear command, I guess you want reuse it
    command.Parameters.Clear();                
    // now create command 2 is OK
    SqlCommand command2 = new SqlCommand(query2, cmd.Connection);
                                      // ^^^ second insert query
    // but add parameteres to command NOT OK
    command.Parameters.AddWithValue("@LName", regLname_text.Text);
                  
