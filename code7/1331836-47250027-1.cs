			services.AddDbContext<PgDbContext>(
				options =>
				{
					options.UseNpgsql(config.GetSection("ConnectionStrings:ApplicationContext").Value)
						.ReplaceService<ISqlGenerationHelper, LowercaseSqlGenerationHelper>()
						.ReplaceService<IQuerySqlGenerator, LowercaseQuerySqlGenerator>()
						.ReplaceService<IHistoryRepository, LowercaseHistoryRepository>();
				},
				ServiceLifetime.Scoped);
			services.AddScoped<ApplicationDbContext>(di => di.GetService<PgDbContext>());
