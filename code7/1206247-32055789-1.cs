    using (var cmd = new SqlCommand("dbo.fnChkXfer", _sqlConn)) {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@FileXferred",SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;
        var p2 = cmd.Parameters.AddWithValue("@UNCFolderPath", DbType.Varchar, 32); // << Set the correct size
        var typeParam = cmd.Parameters.AddWithValue("@FileType", , DbType.Varchar, 32);
        foreach (string strCurrentFolder in strLocalSubFolderList) {
            p2.Value = strCurrentFolder;
            foreach (var typeVal in new[] {"Type 1", "Type 2", ...}) {
                typeParam.Value = typeVal;
                ... // Set values of the remaining parameters
                ... // Use your command as needed
            }
        }
    }
    // After this point all three commands will be closed automatically
