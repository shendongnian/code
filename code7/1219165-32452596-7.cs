    builder.RegisterType<TenantSettings>()
        .As<ITenantSettings>()
        .InstancePerRequest()
        .WithParameter(
            new ResolvedParameter(
                (pi, ctx) => pi.ParameterType == typeof(int) && pi.Name == "tenantId",
                (pi, ctx) => int.Parse(HttpContext.Current.Request.QueryString["id"])));
