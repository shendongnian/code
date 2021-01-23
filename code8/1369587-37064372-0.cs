    using System.Data.SQLite;
    
    using (SQLiteConnection oSqlLiteConnection = new SQLiteConnection("Data Source=" + sFilePath))
    {
         oSqlLiteConnection.Open();
         SQLiteCommand cmd = new SQLiteCommand("Select * from Scalars", oSqlLiteConnection);
         SQLiteDataReader dr = cmd.ExecuteReader();
    
         while (dr.Read())
             Console.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}", dr.GetValue(0), dr.GetValue(1), dr.GetValue(2)));
    }
