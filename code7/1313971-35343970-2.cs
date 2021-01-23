    public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<TestContext>(options =>
                    options.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=Test;Trusted_Connection=True;"));
            services.AddMvc();
            
            RegisterModels(services, new string[] { "UI" }, "UI.Models");
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
