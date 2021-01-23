    [TestClass]
    public class DatabaseTest
    {
        protected string DatabaseConnectionString = $@"Data Source=(localdb)\v11.0; Integrated Security=True";
        protected DatabaseContext DatabaseContext;
        protected string DatabaseName = $"UnitTestDB_{Guid.NewGuid().ToString("N").ToUpper()}";
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public virtual void TestInitialize()
        {
            var instance = new DacServices(DatabaseConnectionString);
            var path     = Path.GetFullPath(Path.Combine(TestContext.TestDir, 
                                            @"..\..\..\Build\Database\Database.dacpac"));
            using (var dacpac = DacPackage.Load(path))
            {
                instance.Deploy(dacpac, DatabaseName);
            }
            DatabaseContext = new DatabaseContext(DatabaseConnectionString);
        }
        [TestCleanup]
        public virtual void TestCleanup()
        {
            DeleteDatabase(DatabaseName);
        }
    }
