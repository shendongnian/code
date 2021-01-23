    using (var remoteConn = new SqlConnection(ConfigurationManager.ConnectionStrings["remoteConnectionString"].ToString()))
    {
        remoteConn.Open();
        using (var remoteCommand = new SqlCommand())
        {
            remoteCommand.Connection = remoteConn;
            string localSql = "";
            string remoteSql = "select * from tracking where last_update > 212316247440000000"; // Julian No = 2015-07-12 11:24:00
    
            remoteCommand.CommandText = remoteSql;
            var remoteReader = await remoteCommand.ExecuteReaderAsync();
            while (remoteReader.Read())
            {
                for (int i = 0; i < 68; i++)
                {
                    localSql += ",'" + remoteReader[i].ToString() + "'";
                }
            }
        }
    }
