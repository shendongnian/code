    oraParam.UdtTypeName = "SYS.ODCINUMBERLIST";
    VArray newArray = new VArray();
    newArray.Array = new Int32[] {12,24,42};
    oraParam.OracleDbType = OracleDbType.Array;
    oraParam.Value = newArray;
    
    string query = @"Select * from TABLE(:1) ";
    OracleCommand command = new OracleCommand(query, MyConnection);
    command.Parameters.Add(oraParam);
    OracleDataReader reader;
    var m_connection = new OracleConnection("The CONNECTION STRING");
    m_connection.Open();
    var reader = command.ExecuteReader();
    reader.Close();
    m_connection.Close();
    
