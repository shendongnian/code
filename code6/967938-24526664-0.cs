    BaseQuery variableQuery = null;
    
    if (roleStatuses != null && roleStatuses.Any())
    {
      foreach (string roleStatus in roleStatuses)
      {
        var status = roleStatus;
        var subQuery = 
            new QueryDescriptor<MySearchDataContract>()
            .Match(s => s.OnField(o => o.Roles.First().RoleStatus)
                         .QueryString(status));
        variableQuery = variableQuery == null ? subQuery : variableQuery || subQuery;
      }
    }
