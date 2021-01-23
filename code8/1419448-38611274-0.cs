    var con = new SqlConnection(m_ConnectString);
    var dbFactory = new NReco.Data.DbFactory(
        System.Data.SqlClient.SqlClientFactory.Instance);
    var dbCmdBuilder = new NReco.Data.DbCommandBuilder(dbFactory);
    var dbAdapter = new NReco.Data.DbDataAdapter(con, dbCmdBuilder);
    
    var selectRecordsList = dbAdapter.Select( 
        new Query("some_table") ).ToList<Dictionary<string,object>>();
