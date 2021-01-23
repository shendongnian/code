    public class MultiTenantAdoNetAppender : AdoNetAppender
    {
        override protected void SendBuffer(IDbTransaction dbTran, LoggingEvent[] events)
        {
            // run for all events
            foreach (LoggingEvent e in events)
            {
                // Code to retrieve the tenant from the context omitted
                string tenant = "";
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
