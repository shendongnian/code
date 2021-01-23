    class Repository : IDisposable
    {
        SqlConnection connection = new SqlConnection("ConnectionString");
        
        void Dispose()
        {
            connection.Dispose();
        }
    }
