    var conn = new ConnectionStringSettings("CRM", "Url=http://machine.co.za/CRM; Username=SOMEUSER; Password=SOMEPASS; Domain=SOMEDOMAIN")
    var crmConnection = new CrmConnection(conn);
    var crmService = new OrganizationService(crmConnection);
    try
    {
        // connection will actually happen here. anything goes wrong, exceptions will be thrown
        var user = crmService.Execute<WhoAmIResponse>(new WhoAmIRequest());
        user.Dump();
    } 
    catch (Exception ex)
    {
        // just a proof of concept
        // ex is of type MessageSecurityException if credentials are invalid
        throw new InvalidOperationException(string.Format(@"connection to {0} cannot be established.", crmConnection.ServiceUri), ex);
    }
