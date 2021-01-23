    /// <summary>
    ///     Initializes a new instance of the <see cref="AppServerDataContext"/>.
    /// </summary>
    public AppServerDataContext() : 
        this(ConfigurationManager.ConnectionStrings["AppServer"].ConnectionString) 
    { }
    /// <summary>
    ///     Initializes a new instance of the <see cref="AppServerDataContext"/>.
    /// </summary>
    /// <param name="connectionString">The full connection string which is used to connect to the database.</param>
    public AppServerDataContext(string connectionString)
        : base(connectionString) { }
