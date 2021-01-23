    from r in DBContext.Resources.ToList()
    where (currentUser == null 
            && ("anonymous,public").Contains(
                r.ResourceGroups.ResourceGroup.ToLower()))
        || (currentUser != null)
    select new
        {                                                          
            ResourceTypeName = r.ResourceType.Name,
            Name = r.Name,
            Version = r.Version,
            Description = r.Description,
            Path = r.Path,
            Active = r.Active
        };
