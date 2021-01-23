    using System.Text.Json.Serialization;
    
    public class Startup
    {
            public void ConfigureServices(IServiceCollection services)
            {
                  services.AddControllers().AddJsonOptions(options =>
                  {
                      options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                      options.JsonSerializerOptions.IgnoreNullValues = true;
                  });
