    using(var connection = new OleDbConnection(ConnectionStringStatic()))
    using(var cmd = connection.CreateCommand())
    {
          cmd.CommandText = @"INSERT INTO tbl_Clients (ipAddress, macAddress, machineName)
                              VALUES (?, ?, ?)";
          cmd.Parameters.Add("@ip", ipAddress);
          cmd.Parameters.Add("@mac", macAddrress);
          cmd.Parameters.Add("@name", machineName);
          connection.Open();
          cmd.ExecuteNonQuery();
    } // <-- Both connection and command are disposed here
