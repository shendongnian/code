    [TestFixture]
    public class BatchRunnerTests
    {
        private readonly IDbConnection _dbConnection;
    
        public BatchRunnerTests()
        {
            _dbConnection = new SqlConnection(@"Data Source=.\sqlexpress; Integrated Security=true; Initial Catalog=Bktb4_CaseMgr_Db"); ;
            _dbConnection.Open();
        }
    
        [Test]
        public void TestBatchRunner()
        {
            var records = new List<Employee>
            {
                new Employee {Age = 1, Name = "foo", Id = 1},
                new Employee {Age = 2, Name = "bar", Id = 2}
            };
    
            var tablwToUpdateFrom = BuildTable(records);
    
            _dbConnection.Execute("update a set Name = b.Name from employees a join " + tablwToUpdateFrom + " b on a.Id = b.Id");
        }
    
        public string BuildTable(List<Employee> data)
        {
            var tableName = "#" + Guid.NewGuid();
    
            _dbConnection.Execute("create table [" + tableName + "] ( Id int null, Name varchar(50) null)");
    
            var batchRunner = new SqlBatchRunner(_dbConnection);
    
            data.ToList().ForEach(x =>
                batchRunner.RecordingConnection.Execute(@"insert into [" + tableName + "] values(@Id, @Name)", x));
    
            batchRunner.Run();
            return tableName;
        }
    }
