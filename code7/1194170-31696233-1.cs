     class Program
        {
            static void Main(string[] args)
            {
                var usr = new User()
                {
    
                    Email = "testmail",
                    Name = "testname"
                };
               
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (IDbConnection dbConnection = new SqlConnection(connection))
                {
                dbConnection.Open();
                    long insert = dbConnection.Insert<User>(usr);
                }
            }
        }
    
        [Table("[User]")]
        public class User
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
    
        }
