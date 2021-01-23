	internal class ExampleClientProvider
	{
	    // Relevant nuget packages:
	    // <package id="Microsoft.CrmSdk.CoreAssemblies" version="9.0.2.9" targetFramework="net472" />
	    // <package id="Microsoft.IdentityModel.Clients.ActiveDirectory" version="4.5.1" targetFramework="net461" />
	    // Relevant imports:
	    // using Microsoft.IdentityModel.Clients.ActiveDirectory;
	    // using Microsoft.Crm.Sdk.Messages;
	    // using Microsoft.Xrm.Sdk;
	    // using Microsoft.Xrm.Sdk.Client;
	    // using Microsoft.Xrm.Sdk.WebServiceClient;
	    private const string TenantId = "<your aad tenant id>";					// from your app registration overview "Directory (tenant) ID"
	    private const string ClientId = "<your client id>";						// from your app registration overview "Application (client) ID"
	    private const string ClientSecret = "<your client secret>";				// secret generated in step 1
	    private const string LoginUrl = "https://login.microsoftonline.com";	// aad login url
	    private const string OrganizationName = "<your organization name>";		// check your dynamics login url, e.g. https://<organization>.<region>.dynamics.com
	    private const string OrganizationRegion = "<your organization region>"; // might be crm for north america, check your dynamics login url	
	    private string GetServiceUrl()
	    {
	        return $"{GetResourceUrl()}/XRMServices/2011/Organization.svc/web";
	    }
	    private string GetResourceUrl()
	    {
	        return $"https://{OrganizationName}.api.{OrganizationRegion}.dynamics.com";
	    }
	    private string GetAuthorityUrl()
	    {
	        return $"{LoginUrl}/{TenantId}";
	    }
	    public async Task<OrganizationWebProxyClient> CreateClient()
	    {
	        var context = new AuthenticationContext(GetAuthorityUrl(), false);
	        var token = await context.AcquireTokenAsync(GetResourceUrl(), new ClientCredential(ClientId, ClientSecret));
	        return new OrganizationWebProxyClient(new Uri(GetServiceUrl()), true)
	        {
	            HeaderToken = token.AccessToken,
	            SdkClientVersion = "9.1"
	        };
	    }
	    public async Task<OrganizationServiceContext> CreateContext()
	    {
	        var client = await CreateClient();
	        return new OrganizationServiceContext(client);
	    }
	    public async Task TestApiCall()
	    {
	        var context = await CreateContext();
	        // send a test request to verify authentication is working
	        var response = (WhoAmIResponse) context.Execute(new WhoAmIRequest());
	    }
	}
