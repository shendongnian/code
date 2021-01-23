    override protected void SendBuffer(IDbTransaction dbTran, LoggingEvent[] events)
    {
        // Code to retrieve the tenant from the context omitted
        string[] usedTenants = GetTenantsFromEvents(events);
        foreach (string tenant in usedTenants)
        {
            using (IDbCommand dbCmd = Connection.CreateCommand())
            {
                // Set the command string
                dbCmd.CommandText = this.CommandText.Replace("[dbo]", string.Format("[{0}]", tenant));
                // Set the command type
                dbCmd.CommandType = CommandType;
                // Send buffer using the prepared command object
                if (dbTran != null)
                {
                    dbCmd.Transaction = dbTran;
                }
                // prepare the command, which is significantly faster
                dbCmd.Prepare();
                // run for all events for tenant, code for select omitted
                foreach (LoggingEvent e in GetEventsForTenant(events, tenant))
                {
                    // clear parameters that have been set
                    dbCmd.Parameters.Clear();
                    // Set the parameter values
                    foreach (AdoNetAppenderParameter param in m_parameters)
                    {
                        param.Prepare(dbCmd);
                        param.FormatValue(dbCmd, e);
                    }
                    // Execute the query
                    dbCmd.ExecuteNonQuery();
                }
            }
        }
    }
