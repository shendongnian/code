    OleDbConnection connectToFile()
    {
        string method = this.ToString() + ".connectToFile";
        Logger.Debug("starting", method);
        Logger.Debug("strFolderPath = " + strFolderPath, method);
        string ACCESS_CONN = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFolderPath.Substring(0,strFolderPath.Length) + ";Extended Properties = \"text; HDR=Yes; FMT=Delimited(,)\";");
        Logger.Debug("ACCESS_CONN = " + ACCESS_CONN, method);
        using (conn = new OleDbConnection())
        {
            try
            {
                conn.ConnectionString = ACCESS_CONN;
                Logger.Debug("connection string: " + conn.ConnectionString, method);
                conn.Open();
                if ("" != conn.ConnectionString)
                    Logger.Debug("Conn is open", method);
                else
                    Logger.Debug("Conn didn't open", method);
                return conn;
            }
            catch (Exception Ex)
            {
                Logger.Error(Ex, method);
                return null;
            }
        }
    
    }
