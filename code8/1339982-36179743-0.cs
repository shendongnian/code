    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Db = new SqlConnection("MyConnectionString");
            // ... initialize data in the test database ...
        }
        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
        public SqlConnection Db { get; private set; }
    }
    public class MyDatabaseTests : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;
        public MyDatabaseTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }
        // ... write tests, using fixture.Db to get access to the SQL Server ...
    }
