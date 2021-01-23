            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("Data Source=*Server*;Initial Catalog=*DBCenter*;Persist Security Info=True;User ID=*User*;password=*Password*");  //from config.xml
            crConnectionInfo.ServerName = builder.DataSource;
            crConnectionInfo.DatabaseName = builder.InitialCatalog;
            crConnectionInfo.IntegratedSecurity = true;
            CrTables = CryRpt1.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            //AssignConnection(CryRpt1);
            ConnectionInfo connection = new ConnectionInfo
            {
                ServerName = "10.20.1.41",
                DatabaseName = "DBCenterMostafavi",
                UserID = "site",
                Password = "123!@#a"
            };
            CryRpt1.SetDatabaseLogon(connection.UserID, connection.Password, connection.ServerName, connection.DatabaseName);
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in CryRpt1.Database.Tables)
            {
                AssignTableConnection(table, connection);
            }
