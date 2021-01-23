	_namedPipeAddress = "net.pipe://localhost/";
	_httpAddress = "http://localhost:8000";
	var host = new ServiceHost(serviceContract, new Uri(_namedPipeAddress), new Uri(_httpAddress));
	host.Description.Behaviors.Add(new ServiceMetadataBehavior { });
	var behaviour = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
	behaviour.InstanceContextMode = InstanceContextMode.Single;
	behaviour.IncludeExceptionDetailInFaults = true;
	// Local Endpoint
	host.AddServiceEndpoint(typeof(ILocalServiceContract), new NetNamedPipeBinding(), "Local");
	host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");
	//// External Endpoint
	var webHttpBidning = new WebHttpBinding { TransferMode = TransferMode.Streamed };
	var externalEndPoint = host.AddServiceEndpoint(typeof(IExternalServiceContract), webHttpBidning, new Uri(_httpAddress));
	externalEndPoint.Behaviors.Add(new WebHttpBehavior());
