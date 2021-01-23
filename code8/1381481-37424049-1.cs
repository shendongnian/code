    conn = new OleDbConnection();
    try
    {
        OleDbConnectionStringBuilder connStrBuilder = new OleDbConnectionStringBuilder();
        connStrBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
        connStrBuilder.DataSource = strFolderPath;
        connStrBuilder.Add("Extended Properties", @"text; HDR=Yes; FMT=Delimited(" + delim + ")");
        conn.ConnectionString = connStrBuilder.ToString();
        Logger.Debug("connection string: " + conn.ConnectionString, method);
        conn.Open();
        if ("" != conn.ConnectionString)
            Logger.Debug("Conn is open with " + conn.ConnectionString + ", state is: " + conn.State, method);
        else
        Logger.Debug("Conn didn't open", method);
        return conn;
    }
    catch (Exception Ex)
    {
        Logger.Error(Ex, method);
        return null;
    }
