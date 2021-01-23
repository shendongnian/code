    static void Main(string[] args)
    {
        string myConnectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=C:\Users\Public\Database1.accdb;";
        using (var con = new OleDbConnection(myConnectionString))
        {
            con.Open();
            using (var cmd = new OleDbCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = 
                        "CREATE TABLE MemoTest (" +
                            "Id COUNTER PRIMARY KEY, " +
                            "MemoField MEMO " +
                        ")";
                cmd.ExecuteNonQuery();
                string lorem =
                        "Lorem ipsum dolor sit amet, consectetur adipisicing elit, " +
                        "sed do eiusmod tempor incididunt ut labore et dolore magna " +
                        "aliqua. Ut enim ad minim veniam, quis nostrud exercitation " +
                        "ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                        "Duis aute irure dolor in reprehenderit in voluptate velit " +
                        "esse cillum dolore eu fugiat nulla pariatur. Excepteur sint " +
                        "occaecat cupidatat non proident, sunt in culpa qui officia " +
                        "deserunt mollit anim id est laborum.";
                cmd.CommandText = "INSERT INTO MemoTest (MemoField) VALUES (?)";
                cmd.Parameters.AddWithValue("?", lorem);
                cmd.ExecuteNonQuery();
                Console.WriteLine(String.Format("Wrote {0} characters to memo field.", lorem.Length));
            }
            con.Close();
        }
    }
