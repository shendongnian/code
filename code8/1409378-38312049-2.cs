    public class MyDalManager: IDALManager
    {
        private readonly string connectionString;
    
        public MyDalManager(string connectionString)
        {
            this.connectionString = connectionString;
        }
    
        public MyMethod()
        {
            //..
    
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Do a call to db here.
            }
        }
    }
    
