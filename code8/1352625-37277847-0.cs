    var commandObject = new OracleCommand
                            {
                                Connection = con,
                                CommandText = "Your Packge Name",
                                CommandType = CommandType.StoredProcedure
                            };
     
    
    commandObject.Connection.Open();    
    commandObject.Parameters.Add("param1", OracleDbType.Int32, ParameterDirection.Input).Value = some int value;
    commandObject.Parameters.Add("param2", OracleDbType.Int32, ParameterDirection.Input).Value = some int value;
    commandObject.Parameters.Add("param3", OracleDbType.Int32, ParameterDirection.Input).Value = some int value;
    commandObject.Parameters.Add("p_xml_type", OracleDbType.NVarchar2, ParameterDirection.Input).Value =some collection
    commandObject.Parameters.Add("param returncode", OracleDbType.Varchar2, 200).Direction = "some string value";
    commandObject.ExecuteNonQuery();
