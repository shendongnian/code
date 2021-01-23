        public static Task OpenWithRetryAsync(this SqlConnection connection, RetryPolicy retryPolicy)
        {
            return retryPolicy.ExecuteAsync(async () =>
            {
                try
                {
                    await connection.OpenAsync();
                }
                catch(SqlException ex)
                {
                    throw CreateSqlException(10060);// got it form http://blog.gauffin.org/2014/08/how-to-create-a-sqlexception/
                }
            });
        }
