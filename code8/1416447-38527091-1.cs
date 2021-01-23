     command.Parameters.Add(new OracleParameter("Id", OracleDbType.NVarchar2));
     command.Parameters.Add(new OracleParameter("firstname", OracleDbType.NVarchar2));
     command.Parameters.Add(new OracleParameter("lastname", OracleDbType.NVarchar2));
    
     command.Parameters["Id"].Direction = ParameterDirection.Output;
     command.Parameters["firstname"].Direction = ParameterDirection.Output;
     command.Parameters["lastname"].Direction = ParameterDirection.Output;
