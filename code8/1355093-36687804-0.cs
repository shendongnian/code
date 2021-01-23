    using (var reader = cmd.ExecuteReader())
    {
       while (reader.Read())
       {
          var blob = reader.GetOracleLob(0);
          var buffer = new byte[128];
          using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Write))
          {
              blob.CopyTo(fs);
          }
       }
    }
