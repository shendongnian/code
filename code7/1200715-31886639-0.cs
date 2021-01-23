    public class Program
    {
        public IConfiguration Configuration { get; set; }
        public Dictionary<string,string> Paths { get; set; } 
        public Program(IApplicationEnvironment app,
               IRuntimeEnvironment runtime,
               IRuntimeOptions options)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(app.ApplicationBasePath, "config.json"))
                .AddEnvironmentVariables()
                .Build();
        }
        public void Main(string[] args)
        {
            var pathKeys = Configuration.GetConfigurationSections("TargetFolderLocations");
            foreach (var pathItem in pathKeys)
            {
                var tmp = Configuration.Get($"TargetFolderLocations:{pathItem.Key}");
                Paths.Add(pathItem.Key, tmp);
            }
            return;
        }
