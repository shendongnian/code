     Uri address1 = new Uri("http://localhost/WFC_Server/");
                Uri address2 = new Uri("net.pipe://localhost/WFC_Server/");
                ServiceHost _host = new ServiceHost(typeof(MyService), address1,address2);
                //Create Metadata exchange for the service
                ServiceMetadataBehavior mexBehavior = new ServiceMetadataBehavior();
                mexBehavior.HttpGetEnabled = true;
                _host.Description.Behaviors.Add(mexBehavior);
                
                //Add service endpoints for the service and mex
               _host.AddServiceEndpoint(typeof(IMyService), new NetNamedPipeBinding(), "MyService.svc");
                
                _host.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );
                _host.Open();
