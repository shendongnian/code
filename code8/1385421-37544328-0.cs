    class ConnectOracle
    { 
        OracleConnection con; 
        void Connect() 
        { 
            con = new OracleConnection(); 
            con.ConnectionString = "User Id=xxx;Password=*****;Data Source=YYYY"; 
            con.Open(); 
            Console.WriteLine("Connected to Oracle ::- " + con.ServerVersion); 
        }
    
        void Close() 
        {
            con.Close(); 
            con.Dispose(); 
        } 
    
        static void Main() 
        { 
            Example OraTest= new OraTest(); 
            OraTest.Connect(); 
            OraTest.Close(); 
        } 
    }
