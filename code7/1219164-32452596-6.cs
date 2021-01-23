    [Fact]
    public void Demonstrate_TenantSettingsFactory_AlwaysResolvesCurrentTenantId()
    {
        int tenantId = 0;
        var builder = new ContainerBuilder();
        builder.RegisterType<TenantSettings>()
            .As<ITenantSettings>()
            .WithParameter(
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(int) && pi.Name == "tenantId",
                    (pi, ctx) => tenantId));
                    
                        
        var container = builder.Build();
        SiteSettings.Initialise(container.Resolve<ITenantSettings>);
        tenantId = 1;
        Assert.Equal("USA Time For Tenant ID 1", SiteSettings.Instance.DefaultTimeZone());
        tenantId = 2;
        Assert.Equal("USA Time For Tenant ID 2", SiteSettings.Instance.DefaultTimeZone());
    }
