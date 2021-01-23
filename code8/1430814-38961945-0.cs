    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("SomeServer", typeof(SomeService).Assembly) {}
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig {
                DefaultContentType = MimeTypes.Json,
                DebugMode = true,
            });
            AppSettings = new DictionarySettings(new Dictionary<string, string> {
                { "Key1", "Value1" },
                { "Key2", "Value2" },
            });
        }
    }
    [Route("/appsettings/{Key}")]
    public class SomeRequest
    {
        public string Key { get; set; }
    }
    public class SomeResponse
    {
        public string Value { get; set; }
    }
    public class SomeService : Service
    {
        public IAppSettings AppSettings { get; set; }
        public SomeResponse Get(SomeRequest request)
        {
            return new SomeResponse { Value = AppSettings.Get<string>(request.Key) };
        }
    }
