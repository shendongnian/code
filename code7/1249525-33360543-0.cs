    private readonly string _providerName;
    private readonly DbProviderFactory _provider;
    public string ConnectionString { get; set; }
    
    public DataFactory()
    {
        var con = ConfigurationManager.ConnectionStrings["TrackerConnection"];
        if (con == null)
            throw new Exception("Failed to find connection");
        ConnectionString = con.ConnectionString;
        _providerName = con.ProviderName;
        _provider = DbProviderFactories.GetFactory(con.ProviderName);
    }
    public IDbConnection Connection
    {
        get
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new Exception($"Failed to create a connection using the connection string named '{_providerName}' in app.config or web.config.");
            connection.ConnectionString = ConnectionString;
            return connection;
        }
    }
