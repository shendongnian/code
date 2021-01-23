      public class Account
            {
                public int AccountId { get; set; }
    
                public virtual List<Operation> Operations { get; set; }
            }
    
            public class Operation
            {
                public Int32 OperationId { get; set; }
    
                public virtual List<Account> Accounts { get; set; }
            }
    
            public class MyDbContext : DbContext
            {
    
                public DbSet<Operation> Operations { get; set; }
    
                public DbSet<Account> Accounts { get; set; }
    
                public MyDbContext()
                    : base("name=cs")
                {
                }
            }
    
            public class OperationAccounts
            {
                public int AccountId { get; set; }
                public int OperationId { get; set; }
    
                public string ExtraInfo { get; set; }
            }
    
            public static ICollection<OperationAccounts> GetOperationAccounts(string connectionString = @"Data Source=.\;Initial Catalog=TestDb;Integrated Security=true")
            {
                ICollection<OperationAccounts> dict = new List<OperationAccounts>();
    
                var sqlBuilder = new SqlConnectionStringBuilder(connectionString);
    
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM OperationAccounts";
    
                    using (var rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                    {
                        while (rdr.Read())
                        {
                            var accountId = rdr.GetInt32(0);
                            var opertationId = rdr.GetInt32(1);
                            var extraColumn = rdr.IsDBNull(2)? string.Empty : rdr.GetString(2);
    
                            dict.Add(new OperationAccounts() { AccountId = accountId, OperationId = opertationId, ExtraInfo = extraColumn });
                        }
                    }
                }
    
                return dict;
            }
    
            public static void SetOperationAccounts(ICollection<OperationAccounts> operationAccounts, string connectionString = "name=cs")
            {
                // Your homework same as GetOperationAccounts
            }
    
            static void Main(string[] args)
            {
                Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());
    
                using (var dbContext = new MyDbContext())
                {
    
                    dbContext.Database.ExecuteSqlCommand(@"ALTER TABLE OperationAccounts ADD ExtraInfo VARCHAR(20) NULL; ");
                    var account = new Account();
                    var operation = new Operation();
    
                    account.Operations = new List<Operation> { operation };
                    operation.Accounts = new List<Account> { account };
    
                    dbContext.Accounts.Add(account);
                    dbContext.SaveChanges();
    
                    var oas = GetOperationAccounts();
                    foreach (var oa in oas)
                    {
                        oa.ToString();
                    }
    
                }
            }
