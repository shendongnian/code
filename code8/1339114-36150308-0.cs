    var notesBuilder = new StringBuilder();
    
    const string SQL = @"SELECT NOTES FROM KETERANGAN";
    using (var cmd = new OracleCommand(SQL, koneksidb.con))
    {
      using (OracleDataReader dr = cmd.ExecuteReader())
      {
        while (dr.Read())
        {
          notesBuilder.Append(dr["NOTES"]);
          notesBuilder.AppendLine(",");
        }
      }
    }
    
    textBox1.Text = notesBuilder.ToString();
