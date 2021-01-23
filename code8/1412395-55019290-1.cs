    using Microsoft.Extensions.Configuration;
    using System.IO;
    public class ConfigSample
    {
        public ConfigSample
        {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
                var root = builder.Build();
                var sampleConnectionString = root.GetConnectionString("your-connection-string");
        }
    }
