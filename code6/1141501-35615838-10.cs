    public interface IRklServiceRuntime
    {    	
    	RklResponse Run(RklRequest request, string hostname, int port, Guid clientId, IHsmLogger logger);
    }
    
    public class VCServiceRuntime : MarshalByRefObject, IRklServiceRuntime
    {
    	public RklResponse Run(
    		RklRequest request, 
    		string hostname, 
    		int port, 
    		Guid clientId,
    		IHsmLogger logger)
    	{
    		Ensure.IsNotNull(request, nameof(request));
    		Ensure.IsNotNullOrEmpty(hostname, nameof(hostname));
    		Ensure.IsNotDefault(port, nameof(port), failureMessage: $"It does not appear that the port number was actually set (port: {port})");
    		Ensure.IsNotNull(logger, nameof(logger));
    
            // these are set here instead of passed in because they are not
            // serializable
    		var clientCert = ApplicationValues.VCClientCertificate;
    		var clientCerts = new X509Certificate2Collection(clientCert);
    
    		using (var client = new VCServiceClient(hostname, port, clientCerts, clientId, logger))
    		{
    			var response = client.RetrieveDeviceKeys(request);
    			return response;
    		}
    	}
    }
