    Principal user = ctx.Web.EnsureUser(accountName);
    var folder = ctx.Web.GetFolderByServerRelativeUrl(folderUrl);
    var roleDefinition = ctx.Site.RootWeb.RoleDefinitions.GetByType(RoleType.Reader);  //get Reader role
    var roleBindings = new RoleDefinitionBindingCollection(ctx) { roleDefinition };
    folder.ListItemAllFields.BreakRoleInheritance(true, false);  //set folder unique permissions
    folder.ListItemAllFields.RoleAssignments.Add(user, roleBindings);
    ctx.ExecuteQuery();
