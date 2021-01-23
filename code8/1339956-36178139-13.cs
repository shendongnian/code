    private static System.Data.Common.DbProviderFactory m_factory = System.Data.Common.DbProviderFactories.GetFactory(typeof(System.Data.SqlClient.SqlClientFactory).Namespace);
    public static void InsertUpdateDataTable(string strTableName, System.Data.DataTable dt)
    {
        if (dt == null)
            throw new System.ArgumentNullException("DataTable dt may not be NULL.");
        using (System.Data.Common.DbDataAdapter daInsertUpdate = m_factory.CreateDataAdapter())
        {
            using (System.Data.Common.DbConnection conn = m_factory.CreateConnection())
            {
                conn.ConnectionString = getConnectionString();
                daInsertUpdate.SelectCommand = conn.CreateCommand();
                daInsertUpdate.SelectCommand.CommandText = string.Format("SELECT * FROM [{0}] WHERE 1 = 2 ", strTableName.Replace("]", "]]"));
                using (System.Data.Common.DbCommandBuilder cmdBuilder = m_factory.CreateCommandBuilder())
                {
                    cmdBuilder.DataAdapter = daInsertUpdate;
                    daInsertUpdate.InsertCommand = cmdBuilder.GetInsertCommand();
                    daInsertUpdate.UpdateCommand = cmdBuilder.GetUpdateCommand();
                } // End Using cmdBuilder
                daInsertUpdate.Update(dt);
            } // End Using conn
        } // End Using daInsertUpdate 
        System.Console.WriteLine(dt);
    }
            
