    private static void Main(string[] args)
        {
            Services.Container.AddService(typeof(DbConnectionHandler),new DbConnectionHandler("connectionstring"));
            Services.Container.AddService(typeof(MyClass), new MyClass((DbConnectionHandler)Services.Container.GetService(typeof(DbConnectionHandler))));
            
            var myclass = (MyClass)Services.Container.GetService(typeof (MyClass));
            Console.WriteLine($"servicecontainertest {myclass.Testshit()}");
            Console.ReadLine();
        }
        public static class Services
        {
            public static ServiceContainer Container { get; set; }
            static Services()
            {
                Container = new ServiceContainer();
            }
        }
        class MyClass
        {
            private DbConnectionHandler _dbHandler { get; set; }
            public MyClass(DbConnectionHandler dbhandler)
            {
                _dbHandler = dbhandler;
            }
            public string Testshit()
            {
                return _dbHandler.Connection.ConnectionString;
            }
        }
        class DbConnectionHandler
        {
            public SqlConnection Connection { get; set; }
            public DbConnectionHandler(string connection)
            {
                Connection = new SqlConnection(connection);
            }
        }
