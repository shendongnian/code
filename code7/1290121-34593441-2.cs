      var str = new System.Data.Odbc.OdbcConnectionStringBuilder();
      str.Add("Uid", "testuser");
      str.Add("Pwd", "testpass");
      str.DSN = "test";
      var con = new OdbcConnection(str.ConnectionString);
