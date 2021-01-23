    public DynamicDbContext(string connString, Type type, List<string> KeyFields)
        : base(GetConnection(connString), GenerateDbCompiledModel(connString, type, KeyFields), true)
    {
        Database.SetInitializer(new NullDatabaseInitializer<DynamicDbContext>());
    }
    private static DbConnection GetConnection(string connectionString)
    {
        var factory = DbProviderFactories.GetFactory("Oracle.ManagedDataAccess.Client");
        var conn = factory.CreateConnection();
        conn.ConnectionString = connectionString;
        return conn;
    }
    public static DbCompiledModel GenerateDbCompiledModel(string connectionString, Type entityType, List<string> _keys)
    {
        string tableName = entityType.Name;
        string schema = entityType.FullName.Replace("Dynamic.Objects.", "").Replace("." + tableName, "");
        _keys = _keys.Select(x =>
        {
            x = x.ToUpper();
            return x;
        }).ToList();
        tableName = entityType.Name;
        DbModelBuilder dbModelBuilder = new DbModelBuilder(DbModelBuilderVersion.Latest);
        var entityMethod = dbModelBuilder.GetType().GetMethod("Entity");
        dbModelBuilder.HasDefaultSchema(schema);
        entityMethod.MakeGenericMethod(entityType).Invoke(dbModelBuilder, new object[] { });
        foreach (var pi in (entityType).GetProperties())
        {
            if (_keys.Contains(pi.Name.ToUpper()))
                dbModelBuilder.Entity(entityType).HasKey(pi.PropertyType, pi.Name);
            else
                switch (pi.PropertyType.Name)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Boolean":
                        dbModelBuilder.Entity(entityType).PrimitiveProperty(pi.PropertyType, pi.Name);
                        break;
                    default:
                        dbModelBuilder.Entity(entityType).DynamicProperty(pi.PropertyType, pi.Name);
                        break;
                }
        }
        var factory = DbProviderFactories.GetFactory("Oracle.ManagedDataAccess.Client"); // Oracle.ManagedDataAccess.Client");
        var conn = factory.CreateConnection();
        conn.ConnectionString = connectionString;
        return dbModelBuilder.Build(conn).Compile();
    }
