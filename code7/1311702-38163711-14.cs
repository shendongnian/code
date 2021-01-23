    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddEmbeddedJsonFile(this IConfigurationBuilder configurationBuilder,
            Assembly assembly, string name, bool optional = false)
        {
            // reload on change is not supported, always pass in false
            return configurationBuilder.AddJsonFile(new EmbeddedFileProvider(assembly), name, optional, false);
        }
    }
