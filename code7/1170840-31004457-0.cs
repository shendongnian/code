    [Test]
    public void ExportProviderResolvesServiceRegisteredByTypeTest()
    {
        // Setup
        var builder = new ContainerBuilder();
        builder.RegisterType<AutofacOnlyComponent1>().As<IAutofacOnlyComponent>();
        var autofacContainer = builder.Build();
        var adapter = new AutofacContainerAdapter(autofacContainer);
        var provider = new ContainerExportProvider(adapter);
        var component = provider.GetExportedValue<IAutofacOnlyComponent>();
        Assert.That(component, Is.Not.Null);
        Assert.That(component.GetType(), Is.EqualTo(typeof(AutofacOnlyComponent1)));
    }
