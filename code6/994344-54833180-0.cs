      public void InsertData(string table, List<string> columns, List<List<object>> data) {
      using (var con = OpenConnection() as MySqlConnection) {
        var bulk = new MySqlBulkLoader(con);
        using (var stream = new MemoryStream()) {
          bulk.SourceStream = stream;
          bulk.TableName = table;
          bulk.FieldTerminator = ";";
          var writer = new StreamWriter(stream);
          foreach (var d in data)
            writer.WriteLine(string.Join(";", d));
          writer.Flush();
          stream.Position = 0;
          bulk.Load();
        }
      }
    }
