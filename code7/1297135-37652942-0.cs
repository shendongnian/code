    // find the azure ad service principal
    var aadsp =
         client.ServicePrincipals.Where(csp => csp.AppId == "00000002-0000-0000-c000-000000000000")
         .ExecuteSingleAsync().Result;
    // create the app role assignment
    var azureDirectoryReadAssignment = new AppRoleAssignment
    {
        PrincipalType = "ServicePrincipal",
        PrincipalId = Guid.Parse(sp.ObjectId), //
        Id = Guid.Parse("5778995a-e1bf-45b8-affa-663a9f3f4d04"), // id for Directory.Read
        // azure active directory resource ID
        ResourceId = Guid.Parse(aadsp.ObjectId) // azure active directory resource ID
    };
    // add it to the service principal
    sp.AppRoleAssignments.Add(azureDirectoryReadAssignment);
    // update the service principal in AAD
    await sp.UpdateAsync();
