    foreach (Table crTable in crTables)
    {
        TableLogOnInfo tableLogOnInfo = crTable.LogOnInfo;
        var connectionInfo = tableLogOnInfo.ConnectionInfo;
        // set connection info stuff here
        crTable.ApplyLogOnInfo(tableLogOnInfo);
    }
