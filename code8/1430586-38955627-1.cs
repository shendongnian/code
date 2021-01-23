    public class MyDataAccessClass {
        private IDbConnectionFactory dbConnectionFactory;
        private string CONNNECTION_STRING = "Connection string here";
        public MyDataAccessClass(IDbConnectionFactory dbConnectionFactory) {
            this.dbConnectionFactory = dbConnectionFactory;
        }
        
        public object RunStoredProc() {
            //Some Setup
            List<object> result = new List<object>();
            using (IDbConnection conn = dbConnectionFactory.CreateConnection(CONNNECTION_STRING)) {
                using (IDbCommand comm = conn.CreateCommand()) {
                    comm.CommandText = "storedProcName";
                    conn.Open();
                    comm.CommandType = CommandType.StoredProcedure;
                    using (IDataReader reader = comm.ExecuteReader()) {
                        while (reader.Read()) {
                            //...Logic to populate result
                        }
                    }
                }
            }
            //Return object based on logic
            return result;
        }
    }
