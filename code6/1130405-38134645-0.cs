    Role role = Role.FromName("Everyone");
    AccessRuleCollection accessRules = item.Security.GetAccessRules();
                    
    foreach (var accessRight in _accessRights)
    {
       AccessRight right = AccessRight.FromName(accessRight.Value);
       accessRules.Helper.RemoveExactMatches(role, right, PropagationType.Any);
    }
    item.Security.SetAccessRules(accessRules);
