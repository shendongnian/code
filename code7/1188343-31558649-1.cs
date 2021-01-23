    // Filter by assets that can be displayed online
    assets = assets.Where(a => a.DisplayOnline);
    
    // Filter by assets that are active
    assets = assets.Where(a => a.Status == EPublishStatus.Active);
    
    // Addtional filters..
    assets = assets.Where(a => x == y);
    
    // Get the string for the dynamic filter
    string dynamicQuery = GetDynamicQuery(assets);
    // Get base OData Asset call (https://api-dev.company.com/odata/Assets)
    IQueryable<Asset> serviceCall = _container.Assets;
    // Apply the new dynamic filter
    serviceCall = serviceCall.AddQueryOption("$filter", dynamicQuery);
    // Resultant OData query (Success!)
    https://api-dev.company.com/odata/Assets?$filter=DisplayOnline and Status eq Models.Status'Active' and (Levels/any(l:l/LevelId eq 18)) or (Levels/any(l:l/LevelId eq 19))
