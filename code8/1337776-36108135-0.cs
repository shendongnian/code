    static string server = "999.999.999.20";
    static string database = "admin_";
    static string user = "root";
    static string pswd = "secret";
    public static void login()
    {
        string connectionString = "Server = " + server + ";database = " 
        + database + ";uid = " + user + ";password = " + pswd + ";"
        +"SslMode=None;"
        +"CharSet=utf8;";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
