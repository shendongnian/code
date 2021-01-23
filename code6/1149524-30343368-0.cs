         try
                {
                    ...
                }
                catch (Exception ex)
                {
    
                 var HttpCurrentContext = HttpContext.Current;
               var  UrlBase = HttpCurrentContext.Request.Url.Host;
               string httpUrl = @"http://";
                if (HttpCurrentContext.Request.IsLocal)
                {
                    UrlBase += ":" + HttpCurrentContext.Request.Url.Port;
                }
                      if (!UrlBase.Contains(httpUrl))
                {
                    UrlBase = httpUrl + UrlBase;
                }
                var UriBase = UriBuilder(UrlBase.ToLowerInvariant().Trim() + "/xrmservices/2011/organization.svc").Uri;
    IServiceConfiguration<IOrganizationService> orgConfigInfo =
                   ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(UriBase);
                var creds = new ClientCredentials();
                using (_serviceProxy = new OrganizationServiceProxy(orgConfigInfo, creds))
                {
    
                    // This statement is required to enable early-bound type support.
                    _serviceProxy.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior());
                    _service = (IOrganizationService)_serviceProxy;
    
                     var log = new Log
                    {
                        Message = ex.Message
                    };
    
                    _service.Create(NewLog);
             }
                    throw;
                }
