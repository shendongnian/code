    using (Oracle.DataAccess.Client.OracleBulkCopy c = new Oracle.DataAccess.Client.OracleBulkCopy(ConnectionString, UseInternalTransaction))
    {
    	c.DestinationTableName = string.Format("{0}.{1}", Schema, Destination);
    	c.WriteToServer(dtLimitStatsDetails);
    	c.Close();
    }
