    public static MySqlConnection CreateConnection(
            string mysqlServer,
            string mysqlUser,
            string mysqlPassword,
            string mysqlDatabase)
    {
        MySqlConnection mysqlConnection = null;
        string mysqlConnectionString = String.Format(
            "server={0};uid={1};pwd={2};database={3};DefaultCommandTimeout={4};",
            mysqlServer, mysqlUser, mysqlPassword, mysqlDatabase, 120);
        /** 
         ** Workaround for MySQL 5.6 bug:
         ** http://stackoverflow.com/questions/30197699/reading-from-stream-failed-mysql-native-password-error 
         */
        int tryCounter = 0;
        bool isConnected = false;
        do
        {
            tryCounter++;
            try
            {
                mysqlConnection = new MySqlConnection();
                mysqlConnection.ConnectionString = mysqlConnectionString;
                mysqlConnection.Open();
                if (mysqlConnection.State == ConnectionState.Open)
                {
                    isConnected = true;
                }
            }
            catch (MySqlException ex)
            {
                if (tryCounter < 10)
                {
                    DebugLog.Dump(ex.ToString(), DebugLog.MainLogFilePath);
                    Thread.Sleep(10000); // 10 seconds.
                }
                else
                {
                    throw;
                }
            }
        } while (!isConnected);
        return mysqlConnection;
    }
