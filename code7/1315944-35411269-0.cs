    public void ConfigureServices(IServiceCollection services)
    {
          services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
          services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));
          services.Scan(scan => scan
                  .FromAssembliesOf(typeof(IMediator), typeof(MyHandlerOne.Handler))
                  .FromAssembliesOf(typeof(IMediator), typeof(MyHandlerTwo.Handler))
                 .AddClasses()
                 .AsImplementedInterfaces());
    }
