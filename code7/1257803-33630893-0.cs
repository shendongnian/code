    string conS ="..."; // connection string
    var param = 1;
    using (var connection = new OleDbConnection(conS))
    {
           string queryString = "SELECT stockName FROM Stock WHERE stockLowCalculation < @var"
           var cmd = new OleDbCommand(queryString, connection);
           cmd.Parameters.Add(new OleDbParameter("@var", param));
           connection.Open();
           OleDbDataAdapter adapt = new OleDbDataAdapter(cmd);                    
    }
