    foreach (Table crTable in report.Database.Tables)
    {
        TableLogOnInfo tableLogOnInfo = crTable.LogOnInfo;
        var connectionInfo = tableLogOnInfo.ConnectionInfo;
        // use connectionInfo to set database credentials
        crTable.ApplyLogOnInfo(tableLogOnInfo);
    }
    
    
