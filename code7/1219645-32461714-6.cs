    public void ConfigureServices(IServiceCollection services)
    {
        var myOptions = new MyOptions();
        Configuration.GetSection("SomeSection").Bind(myOptions);
    }
