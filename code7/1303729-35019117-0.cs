    // create a ReportDocument
    using (ReportDocument reportDoc = new ReportDocument())
    {
    	reportDoc.Load(path); // path to your .rpt file
    	
    	// get the connection string you want to use
    	SqlConnectionStringBuilder conInfo = new SqlConnectionStringBuilder("<your connection string>");
    	 
    	Tables crTables = reportDoc.Database.Tables;
    	int tablecounter = 0;
    	foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
    	{
    		CrystalDecisions.Shared.TableLogOnInfo logonInfo = crTable.LogOnInfo;
    
    		logonInfo.ConnectionInfo = new ConnectionInfo()
    		{
    			DatabaseName = conInfo.InitialCatalog,
    			ServerName = conInfo.DataSource
    		};
    		if (conInfo.IntegratedSecurity)
    		{
    			logonInfo.ConnectionInfo.IntegratedSecurity = true;
    		}
    		else
    		{
    			logonInfo.ConnectionInfo.UserID = conInfo.UserID;
    			logonInfo.ConnectionInfo.Password = conInfo.Password;
    		}
    		
    		crTable.ApplyLogOnInfo(logonInfo);
    	}
    }
