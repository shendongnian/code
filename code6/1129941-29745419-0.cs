     using (var ec = new EntityConnection(connstr.ConnectionString))
     {
         var sqlConn = ec.StoreConnection as SqlConnection;
         sqlConn.Open();
         var dataSource = sqlConn.DataSource;
         var userId = sqlConn.Credential.UserId;
         var password = sqlConn.Credential.Password;
     }
