    public IConfiguration Configuration { get; set; }
    public Startup()
    {
     Configuration = new Configuration()
        .AddJsonFile("config.json")
        .AddEnvironmentVariables();    <----- will cascade over config.json
    }
