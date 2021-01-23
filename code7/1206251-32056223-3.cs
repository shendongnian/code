    Dictionary<string,string> strLocalSubFolderDict = new Dictionary<string, string>();
    strLocalSubFolderDict.Add( "Type 1", "Directory 1");
    strLocalSubFolderDict.Add( "Type 2", "Directory 2");
    strLocalSubFolderDict.Add( "Type 3", "Directory 3");
    
    using (SqlCommand sqlComm = new SqlCommand("dbo.fnChkXfer", _sqlConn))
    {
         sqlComm.CommandType = CommandType.StoredProcedure;
         sqlComm.Parameters.Add("@FileXferred", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;
         sqlComm.Parameters.Add("@UNCFolderPath");
         sqlComm.Parameters.Add("@FileType");
    
         foreach (var val in strLocalSubFolderDict)
         {
             sqlComm.Parameters["@UNCFolderPath"].Value = val.Value;
             sqlComm.Parameters["@FileType"].Value = val.Key;
             sqlComm.ExecuteNonQuery();
             //    ...if files not transferred, then transfer them
          }
    }
