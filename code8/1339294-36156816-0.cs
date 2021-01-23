    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Policy> policy1 = PolicySelectAll();
            IEnumerable<Policy> policy2 = PolicyFindByLastFour("093D");
        }
        public static IEnumerable<Policy> PolicySelectAll()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperConnection"].ToString());
            var sql = "SELECT * FROM Policy";
            IEnumerable<Policy> policy;
            using (db)
            {
                db.Open();
                policy = db.Query<Policy>(sql);
                db.Close();
            }
            return policy;
        }
        public static IEnumerable<Policy> PolicyFindByLastFour(string LastFour)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperConnection"].ToString());
            var sql = string.Format("SELECT * FROM Policy WHERE PolicyNumber LIKE '%{0}'", LastFour);
            IEnumerable<Policy> policy;
            using (db)
            {
                db.Open();
                policy = db.Query<Policy>(sql);
                db.Close();
            }
            return policy;
        }
    }
