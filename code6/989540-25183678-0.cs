    MySqlConnection conn = new MySqlConnection(connStr)
    try
    {
         ....
    }
    finally
    {
        conn.Close();
    }
