    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Text;
    
    namespace TestApp
    {
        public class TestDb : DbContext
        {
            public TestDb() : base(CreateConnection("TestDb"), true)
            {
            }
    
            static DbConnection CreateConnection(string dbName)
            {
                string encodedCs = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
                string decodedCs = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCs));
                return new SqlConnection(decodedCs);
            }
        }
    }
