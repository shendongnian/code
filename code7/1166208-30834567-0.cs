    dbConnection.Open();
    OracleCommand comm = new OracleCommand(query, dbConnection);               
    int count = (int)comm.ExecuteScalar();
    Console.WriteLine(count);              
    Console.WriteLine("Connecting Okay");
