    using (var sqlComm1 = new SqlCommand("dbo.fnChkXfer", _sqlConn))
    using (var sqlComm2 = new SqlCommand("dbo.fnChkXfer", _sqlConn))
    using (var sqlComm3 = new SqlCommand("dbo.fnChkXfer", _sqlConn)) {
        sqlComm1.CommandType = CommandType.StoredProcedure;
        var c1p1 = sqlComm1.Parameters.Add("@FileXferred",SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;
        var c1p2 = sqlComm1.Parameters.AddWithValue("@UNCFolderPath", DbType.Varchar, 32); // << Set the correct size
        sqlComm1.Parameters.AddWithValue("@FileType", "Type 1"); // This one is fixed
        var c2p1 = ... // Do the same for parameters of other commands
        foreach (string strCurrentFolder in strLocalSubFolderList) {
            c1p2.Value = strCurrentFolder;
            ... // Set values of the remaining parameters
            ... // Use your commands as needed
        }
    }
    // After this point all three commands will be closed automatically
