    SqlConnection dbConnection;
    using (dbConnection = new SqlConnection(connectionString))
    {
        /* 
           Whatever Dapper stuff you want to do. Dapper will open the
           connection and the using will tear it down.
        */
    }
