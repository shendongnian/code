    OdbcConnection odbcConn;
    OdbcCommand odbcCmd;
    OdbcParameter odbcParam; 
    public override void AcquireConnections(object Transaction)
    {
        string connectionString;
        connectionString = this.Connections.OTRSDB.ConnectionString;
        odbcConn = new OdbcConnection(connectionString);
        odbcConn.Open();
    }  
    public override void PreExecute()
    {
        odbcCmd = new OdbcCommand("UPDATE xdwdata_Contracts " +
        "SET " +
          " reference = ? " + 
          " ,customer = ? " + 
          " ,contract = ? " + 
          " ,status = ? " + 
          " ,change_date = ? " + 
        " WHERE " +
          " id = ? " +
          " AND client = ? ", odbcConn);
        odbcParam = new OdbcParameter("@reference", OdbcType.VarChar, 128);
        odbcCmd.Parameters.Add(odbcParam);
        odbcParam = new OdbcParameter("@customer", OdbcType.VarChar, 40);
        odbcCmd.Parameters.Add(odbcParam);
        odbcParam = new OdbcParameter("@contract", OdbcType.VarChar, 14);
        odbcCmd.Parameters.Add(odbcParam);
        odbcParam = new OdbcParameter("@status", OdbcType.VarChar, 16);
        odbcCmd.Parameters.Add(odbcParam);
        odbcParam = new OdbcParameter("@change_date", OdbcType.DateTime);
        odbcCmd.Parameters.Add(odbcParam);
        odbcParam = new OdbcParameter("@id", OdbcType.Int, 11);
        odbcCmd.Parameters.Add(odbcParam);
        odbcParam = new OdbcParameter("@client", OdbcType.VarChar, 2);
        odbcCmd.Parameters.Add(odbcParam);       
    }
    public override void Eingabe0_ProcessInputRow(Eingabe0Buffer Row)
    {        
            odbcCmd.Parameters["@reference"].Value = Row.reference;
            odbcCmd.Parameters["@customer"].Value = Row.customer;
            odbcCmd.Parameters["@contract"].Value = Row.contract;
            odbcCmd.Parameters["@status"].Value = Row.status;
            odbcCmd.Parameters["@change_date"].Value = Row.changedate;
            odbcCmd.Parameters["@id"].Value = Row.id;
            odbcCmd.Parameters["@client"].Value = Row.client;
            odbcCmd.ExecuteNonQuery();        
    }
    public override void ReleaseConnections()
    {
        odbcConn.Close();
    }  
