    using(SQLiteConnection con = new SQLiteConnection(String.Format(@"Data Source={0};Version=3;New=False;", "./db/mydatabase.sdb")) {
       con.Open();
       using (SQLiteCommand cmd = con.CreateCommand())
       {
          cmd.CommandText = @"SELECT BookName FROM Books WHERE BookId=1 LIMIT 1;";
          using (SQLiteDataReader reader = cmd.ExecuteReader()) {
             if (reader.HasRows && reader.Read()) {
                oResult = Convert.ToString(reader["BookName"]);
             }
             reader.Close();
          }
       }
       con.Close();
    }
