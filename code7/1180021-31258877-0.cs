    IDbCommand command = MyConnection.CreateCommand();
    command.CommandText = statement;
    var reader = command.ExecuteReader();
   
    while(reader.Read()){
        //Logic for first result
    }
    reader.NextResult();
   
    while(reader.Read()){
        //Logic for second result
    }
