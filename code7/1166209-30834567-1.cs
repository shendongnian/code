    dbConnection.Open();
    OracleCommand comm = new OracleCommand(query, dbConnection);               
    decimal count = (decimal)comm.ExecuteScalar();
    Console.WriteLine(count);              
    Console.WriteLine("Connecting Okay");
