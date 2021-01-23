    YourModel model = ...
    string user = User.Identity.Name;
    PrincipalContext context = new PrincipalContext(ContextType.Domain, "DOMAINNAME");
    model.IsAuthorized  = user.IsMemberOf(ctx, IdentityType.SamAccountName, "GroupName");
    return View(model);
