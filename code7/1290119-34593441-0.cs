      var str = new DbConnectionStringBuilder();
      str.Add("Uid", "testuser");
      str.Add("Pwd", "testpass");
      str.Add("DSN", "test");
      var con = new OdbcConnection(str.ConnectionString);
