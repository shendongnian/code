    using Configuration = Formo.Configuration;
    .......
    /// <summary>
    /// Gets the data source from app.config file
    /// </summary>
    /// <returns></returns>
    public string GetMyDataSource()
    {
        dynamic config = new Configuration();
        return config.MyDataSource;
    }
