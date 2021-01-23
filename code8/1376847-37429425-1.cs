    string connStr = @"User Id=xxxxxxxxxxx;Password=xxxx;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=VS-ORACLE.xxxxxxxx.de)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl.xxxxxxxx.de)))";
    using (var connection = new OracleConnection() { ConnectionString = connStr })
    {
      connection.Open();
      using (var ctx = new GlobalAttributeContext(connection, true))
      {
        var globalAttributes = ctx.GlobalAttributes.ToList();
        foreach (GlobalAttribute ga in globalAttributes)
        {
          Console.WriteLine("Name: {0}, Value: {1}", ga.Attribute, ga.Value);
        }
      }
    }
