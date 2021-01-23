    	public static void Configure(System.ServiceModel.ServiceConfiguration config)
		{
			Uri netTcpAddress = config.BaseAddresses.FirstOrDefault(x => x.Scheme == Uri.UriSchemeNetTcp);
			if (netTcpAddress == null)
			{
				throw new InvalidOperationException("No base address matches the endpoint binding net.tcp");
			}
			Uri metaAddress = config.BaseAddresses.FirstOrDefault(x => x.Scheme == Uri.UriSchemeHttp);
			if (metaAddress == null)
			{
				throw new InvalidOperationException("No base address matches the endpoint binding http used for metadata");
			}
			config.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
			NetTcpBinding wsBind = new NetTcpBinding(SecurityMode.Transport);
			ServiceEndpoint endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IInternalESensService)), wsBind, new EndpointAddress(netTcpAddress));
			config.AddServiceEndpoint(endpoint);
			Binding mexBinding = MetadataExchangeBindings.CreateMexHttpBinding();
			ContractDescription contractDescription = ContractDescription.GetContract(typeof(IMetadataExchange));
			contractDescription.Behaviors.Add(new ServiceMetadataContractBehavior(true));
			ServiceEndpoint mexEndpoint = new ServiceEndpoint(contractDescription, mexBinding, new EndpointAddress(metaAddress));
			mexEndpoint.Name = "mexTest";
			config.AddServiceEndpoint(mexEndpoint);
			config.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
		}
