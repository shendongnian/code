            List<string> strLocalSubFolderList = new List<string>();
            List<string> typesList = new List<string>();
            typesList.Add("Type 1");
            typesList.Add("Type 2");
            typesList.Add("Type 3");
            using (SqlCommand sqlComm = new SqlCommand("dbo.fnChkXfer", _sqlConn))
            {
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.Add("@FileXferred", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;
                sqlComm.Parameters.Add("@UNCFolderPath");
                sqlComm.Parameters.Add("@FileType");
                foreach (var directval in strLocalSubFolderList)
                {
                    foreach ( var typeval in typesList)
                    {
                        sqlComm.Parameters["@UNCFolderPath"].Value = directval;
                        sqlComm.Parameters["@FileType"].Value = typeval;
                        sqlComm.ExecuteNonQuery();
                        //    ...if files not transferred, then transfer them
                    }
                }
            }
