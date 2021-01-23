    public static IEnumerable<Scope> Get()
    {
        Scope profileScope = StandardScopes.Profile;
        profileScope.IncludeAllClaimsForUser = true; // set this property to true
        return new List<Scope>()
        {
            StandardScopes.OpenId,
            profileScope,
            
            new Scope()
            {
                Name = "somename",
                DisplayName = "some display name",
                Description = "some description",
                Type = ScopeType.Resource
            }
        };
    } 
