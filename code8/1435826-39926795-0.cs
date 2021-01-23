    Task<string> ICommunicationListener.OpenAsync(CancellationToken cancellationToken)
    {
        var context = FabricRuntime.GetActivationContext();
        var endpoint = context.GetEndpoint(_endpointName);
        var config = context.GetConfigurationPackageObject("Config");
        var environment = config.Settings.Sections["Environment"].Parameters["ASPNETCORE_ENVIRONMENT"].Value;
        var serverUrl = $"{endpoint.Protocol}://{FabricRuntime.GetNodeContext().IPAddressOrFQDN}:{endpoint.Port}";
        _webHost = new WebHostBuilder().UseKestrel()
                                       .UseContentRoot(Directory.GetCurrentDirectory())
                                       .UseStartup<Startup>()
                                       .UseEnvironment(environment)
                                       .UseUrls(serverUrl)
                                       .Build();
        _webHost.Start();
        return Task.FromResult(serverUrl);
    }
