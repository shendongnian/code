    [Test]
    public void Handle_Condfigure_OverridesRegistrationForClassD()
    {
        var container = ApplicationConfiguration.Initialize();
        container.Configure(x =>
        {
            x.For<ICommandHandler<ClassD>>().Use<SpecialInsertDCommandHandler>();
        });
        var resultD = container.GetInstance<ICommandHandler<ClassD>>();
        Assert.That(resultD.GetType() == typeof(SpecialInsertDCommandHandler));
    }
