    OracleConnection connection = GetConnection();
    OracleCommand command = connection.CreateCommand();
    command.CommandText = procedure;
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.Add("INID", OracleDbType.Int32).Value = person.PersonID;
    command.Parameters.Add("REFCURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
