    public class MyDal
    {
        public List<string> GetSomething()
        {
            var strQuery = string.Format(SQLCOMMAND);
            var result = new List<String>();
            using (var con = DbConnection())
            {
                result = con.Query<String>(strQuery).ToList();
            }
            return result;
        }
        
        public static OleDbConnection DbConnection()
        {
            return new OleDbConnection(myConnectionString);
        }
    }
