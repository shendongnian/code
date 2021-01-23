    public class Startup
    {
    public void Configuration(IAppBuilder app)
    {
        // Create JsonSerializer with StringEnumConverter.
        var serializer = new JsonSerializer();
        serializer.Converters.Add(new StringEnumConverter());
        // Register the serializer.
        GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);
        app.MapSignalR();
        }
    }
