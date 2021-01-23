    internal class Employee
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
    
    [TestFixture]
    public class DapperTests
    {
        private IDbConnection _connection;
    
        [SetUp]
        public void SetUp()
        {
            _connection = new SqlConnection(@"Data Source=.\sqlexpress; Integrated Security=true; Initial Catalog=YOURDB");
            _connection.Open();
        }
    
        [TearDown]
        public void TearDown()
        {
            _connection.Execute("drop table employees");
            _connection.Close();
        }
    
        [Test]
        public void BulkInserTest()
        {
            _connection.Execute("create table employees(Id int, Name varchar(100), Age int)");
            _connection.Execute("insert into employees(Id, Name) values(1, 'xxx'), (2, 'yyy')");
    
            _connection.Execute(@"update employees set Name = @Name where Id = @Id",
                new List<Employee> 
                {
                    new Employee{Age = 1, Name = "foo", Id = 1},
                    new Employee{Age = 2, Name = "bar", Id = 2}
                });
    
            var result = _connection.Query<Employee>("select * from employees").ToList();
            
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.FirstOrDefault(x => x.Id == 1).Name == "foo");
            Assert.That(result.FirstOrDefault(x => x.Id == 2).Name == "bar");
    
        }
    }
