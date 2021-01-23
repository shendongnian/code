    using Microsoft.Xrm.Sdk;
    using System.ServiceModel.Description;
    
    string serviceUri = "https://{OrganizationName}.{Servername}/XRMServices/2011/Organization.svc";
    var credentials = new ClientCredentials();
    credentials.UserName.UserName = "YourUsername";
    credentials.UserName.Password = "YourPassword"; 
    var crmOrganizationService = new OrganizationServiceProxy(new Uri(serviceUri), null, credentials, null);
