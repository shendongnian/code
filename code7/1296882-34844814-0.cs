    ActiveDirectoryClient client = AuthenticationHelper.GetActiveDirectoryClient();
    var app = (await client.Applications.GetByObjectId("applicationObjectId").ExecuteAsync());
    var servicePrincipal = await client.ServicePrincipals.GetByObjectId("servicePrincipalObjectId").ExecuteAsync();
    var appRole = app.AppRoles.First(r => r.DisplayName == "my role");
    var mygroup = (Group)(await client.Groups.ExecuteAsync()).CurrentPage.FirstOrDefault();  
