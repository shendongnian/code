    class CrystalDatabase
        {
    
            public static TableLogOnInfo GetODBCTableLogOnInfo(string ODBCName, string serverName, string databaseName, string userID, string password)
            {
                CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag connectionAttributes = new CrystalDecisions.ReportAppServer.DataDefModel.PropertyBag();
    
                connectionAttributes.EnsureCapacity(3);
                connectionAttributes.Add(DbConnectionAttributes.CONNINFO_CONNECTION_STRING, string.Format("DSN={0};Driver={{SQL Server}}", ODBCName));
                connectionAttributes.Add("Server", serverName);
                connectionAttributes.Add("UseDSNProperties", false);
    
                DbConnectionAttributes attributes = new DbConnectionAttributes();
                attributes.Collection.Add(new NameValuePair2("Database DLL", "crdb_odbc.dll"));
                attributes.Collection.Add(new NameValuePair2("QE_DatabaseName", databaseName));
                attributes.Collection.Add(new NameValuePair2("QE_DatabaseType", "ODBC (RDO)"));
                attributes.Collection.Add(new NameValuePair2("QE_LogonProperties", connectionAttributes));
                attributes.Collection.Add(new NameValuePair2("QE_ServerDescription", serverName));
                attributes.Collection.Add(new NameValuePair2("QE_SQLDB", true));
                attributes.Collection.Add(new NameValuePair2("SSO Enabled", false));
    
                ConnectionInfo connectionInfo = GetConnectionInfo(serverName, databaseName, userID, password);
                connectionInfo.Attributes = attributes;
                connectionInfo.Type = ConnectionInfoType.CRQE;
                connectionInfo.IntegratedSecurity = false;
                TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                return tableLogOnInfo;
            }
    
            public static ConnectionInfo GetConnectionInfo(string serverName, string databaseName, string userID, string password)
            {
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = serverName;
                connectionInfo.DatabaseName = databaseName;
                connectionInfo.UserID = userID;
                connectionInfo.Password = password;
    
                return connectionInfo;
            }
        }
