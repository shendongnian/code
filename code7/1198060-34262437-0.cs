    var task = Task.Factory.StartNew(() => {
        //your code or @Randy here with little change:
        using (var remoteConn = new SqlConnection(ConfigurationManager.ConnectionStrings["remoteConnectionString"].ToString()))
        {
            remoteConn.Open();
            using (var remoteCommand = new SqlCommand())
            {
                remoteCommand.Connection = remoteConn;
                string localSql = "";
                string remoteSql = "select * from tracking where last_update > 212316247440000000"; // Julian No = 2015-07-12 11:24:00
                remoteCommand.CommandText = remoteSql;
                var remoteReader = remoteCommand.ExecuteReader();
                while (remoteReader.Read())
                {
                    for (int i = 0; i < 68; i++)
                    {
                        localSql += ",'" + remoteReader[i].ToString() + "'";
                    }
                }
            }
        }
    });
    //use can use 'task.wait();' to waiting for complete the task.
