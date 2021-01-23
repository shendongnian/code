       public IMapper Mapper { get; set; }
       private MapperConfiguration MapperConfiguration { get; set; }
       public void ConfigureServices(IServiceCollection services)
       {
            MapperConfiguration MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
            });
        
            Mapper = MapperConfiguration.CreateMapper();
    
            services.AddInstance(Mapper);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // AutoMapper Configuration moved out of here.
        }
