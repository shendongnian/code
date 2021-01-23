    public void Config(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
        jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
        app.UseWebApi(config);
    }
