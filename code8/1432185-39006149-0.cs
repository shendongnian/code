    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
    [TestFixture]
    public class DapperExtensions
    {
        private SqlConnection _connection;
    
        [SetUp]
        public void Init()
        {
            _connection = new SqlConnection(@"Data Source=.\sqlexpress;Integrated Security=true; Initial Catalog=mydb");
            _connection.Open();
    
            _connection.Execute("create table Person(Id int not null, FirstName varchar(100) not null, LastName varchar(100) not null)");
            _connection.Execute("insert into Person(Id, FirstName, LastName) values (1, 'Bill', 'Gates')");
        }
    
        [TearDown]
        public void Teardown()
        {
            _connection.Execute("drop table Person");
            _connection.Close();
        }
    
        [Test]
        public void Test()
        {
            var result = _connection.Get<Person>(1);
        }
    }
