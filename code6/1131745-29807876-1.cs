    Principal user = ctx.Web.EnsureUser(accountName);
    var list = ctx.Web.Lists.GetByTitle(listTitle);
    var folderItem = list.LoadItemByUrl(folderUrl);
    var roleDefinition = ctx.Site.RootWeb.RoleDefinitions.GetByType(RoleType.Reader);  //get Reader role
    var roleBindings = new RoleDefinitionBindingCollection(ctx) { roleDefinition };
    folderItem.BreakRoleInheritance(true, false);  //line 6
    folderItem.RoleAssignments.Add(user, roleBindings);
    ctx.ExecuteQuery();
