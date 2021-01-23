    public class Startup
    {
        public IConfigurationRoot ArticleConfiguration { get; set; }
    
        public Startup(IHostingEnvironment env)
        {
            ArticleConfiguration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("articles.json")
                .Build();
        }
    
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
    
            services.Configure<ArticleContainer>(ArticleConfiguration);
        }
    }
