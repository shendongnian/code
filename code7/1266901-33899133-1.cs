    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.Register(c => new SqlFactory("Data Source=TEST;Initial Catalog=test;Integrated Security=True")).As<IDatabaseFactory>();
        builder.RegisterType<DatabaseHelper>();
        var container = builder.Build();
        using (var scope = container.BeginLifetimeScope())
        {
            var dbHelper = scope.Resolve<DatabaseHelper>();
            
            dbHelper.ExecuteQuery();
            Console.Read();
        }
    }
