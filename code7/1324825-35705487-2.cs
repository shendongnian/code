    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().AddJsonOptions( op => {
          op.SerializerSettings.Converters.Add(new StringEnumConverter());
      });
