    using (var appHost = new BasicAppHost
    {
        ConfigureAppHost = host => {
            host.Plugins.Add(new ValidationFeature());
        },
        ConfigureContainer = c => {
            c.RegisterValidators(typeof(ApplicationValidator).Assembly);
        }
    }.Init())
    {
        var myValidator = appHost.TryResolve<IValidator<MyRequest>>();
        var result = myValidator.Validate(new MyRequest { ... });
        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Errors.Count, Is.EqualTo(1));
    }
