    using Microsoft.Xrm.Client;
    using Microsoft.Xrm.Sdk;
    IOrganizationService organizationService = null;
    string connectionString = string.Format(@"Url={Your url from IP:port/Organization}; Domain={Your Domain}; Username={User name}; Password={Password}");
    Microsoft.Xrm.Client.CrmConnection connection = CrmConnection.Parse(connectionString);
    organizationService = new Microsoft.Xrm.Client.Services.OrganizationService(connection);
