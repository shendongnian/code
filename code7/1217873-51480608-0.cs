    private readonly static string ConnectionKey = @"C:\Users\Mehmeto\Documents\Visual Studio 2015\Projects\......\bin\myDB.sqlite";
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + ConnectionKey + ";Version=3;", true);
            return conn;
        }
