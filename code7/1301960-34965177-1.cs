    class ValueObj
    {
        public static string[] postfix(string table) //note the static and string[]
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM " + table;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            List<string> list = new List<string>();
            while (sqlite_datareader.Read())
            {
                list.Add(sqlite_datareader.GetString(1));
            }
            return list.ToArray(); // returns string[]
        }
        public string[] postfixList = postfix("postfixList"); // now it is ok
    }
