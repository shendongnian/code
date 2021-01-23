    using System; 
    using Oracle.DataAccess.Client; 
    
    class MyClass
    { 
        OracleConnection con; 
        void Connect() 
        { 
            con = new OracleConnection(); 
            con.ConnectionString = "yourconnectionstring"; 
            con.Open(); 
        }
    
        void Close() 
        {
            con.Close(); 
            con.Dispose(); 
        } 
    
        static void Main() 
        { 
            //some code
        } 
    }
