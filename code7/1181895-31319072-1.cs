        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
            services.Configure<AppSettings>(configuration.GetConfigurationSection("AppSettings"));
            // Add EF services to the services container.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]));
            services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
            services.AddSingleton<IProposalDataRepository, ProposalDataRepository>();
            services.AddSingleton<IPositionDataRepository, PositionDataRepository>();
            services.AddSingleton<IMandatoryReqDataRepository, MandatoryReqDataRepository>();
            services.AddSingleton<IRatedReqDataRepository, RatedReqDataRepository>();
        }
