    ConnectionInfo crConInfo = new ConnectionInfo();
    TableLogOnInfo crTblLogonInfo = new TableLogOnInfo();
    crConInfo.ServerName = "db_server_name_or_ip";
    crConInfo.DatabaseName = "database_name";
    crConInfo.UserID = "db_user_name";
    crConInfo.Password = "db_password";  
    'crDoc1 is your ReportDocument
    'dtDataTable is your DataTable
    'Set DataSource to your DataTable
	crDoc1.SetDataSource(dtDataTable)
    'after setting the DataSource apply Logon credentials to each table in ReportDocument
    Tables CrTables = crDoc1.Database.Tables;
    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables) {
        crTblLogonInfo = CrTable.LogOnInfo;
        crTblLogonInfo.ConnectionInfo = crConInfo;
        CrTable.ApplyLogOnInfo(crTblLogonInfo);
    }
    crDoc1.Refresh();
    CrystalReportViewer1.ReportSource = crDoc1;
