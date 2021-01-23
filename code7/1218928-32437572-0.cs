    class connection
        {
    
            public SqlConnection con;               
            public SqlCommand cmd = new SqlCommand();
    
            public connection(string connectionString)
            {
    
                con = new SqlConnection(connectionString);
       
            }
