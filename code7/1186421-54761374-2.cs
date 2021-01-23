    public class Startup
    {
        public IConfigurationRoot ArticleConfiguration { get; set; }
    
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("articles.json");
    
            ArticleConfiguration = builder.Build();
        }
    
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
    
            services.Configure<ArticleContainer>(ArticleConfiguration);
        }
    }
