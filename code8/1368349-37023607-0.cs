    public interface IDbContext
    {
        void Connect();
        void DisConnect();
        IDbCommand GetDbCommand(string query, string[] parameters);
    }
    public class DbContext : IDbContext
    {
        public IDbConnection Conn { get; set; }
        public void Connect()
        {
            // your code here
        }
        public void DisConnect()
        {
            // your code here
        }
        public IDbCommand GetDbCommand(string query, string[] parameters)
        {
            // parameter handling
            return new SqlCommand(query, (SqlConnection)Conn);
        }
    }
    public class YourClass
    {
        private string name;
        private string address;
        private string phn;
        public void InsertData(IDbContext context)
        {
            context.Connect();
            var cmd = context.GetDbCommand("Insert into Person values ('{0}','{1}','{2}')", new string[] { name, address, phn });
            cmd.ExecuteNonQuery();
            context.DisConnect();
        }
    }
