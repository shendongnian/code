    // Base query
    var query = db.PORequests
               .Include(i => i.POItems)
               .AsQueryable();
    // Filter
    if (!string.IsNullOrEmpty(poNumber))
    {
        query = query.Where(s => s.PONumber.Contains(poNumber));
    }
    if (!string.IsNullOrEmpty(AppropNumber))
    {
        query = query.Where(x => x.AppropNumber.Contains(AppropNumber));
    }
    if (!string.IsNullOrEmpty(ContractNumber))
    {
        query = query.Where(x => x.ContractNumber.Contains(ContractNumber));
    }
    if (!string.IsNullOrEmpty(ItemDescription))
    {
       query = query.Where(x => x.POItems.Any(i => i.Description.Contains(ItemDescription)));
    }
    // Sort
    switch (sortOrder)
    {
        case "PONumber_desc":
            query = query.OrderByDescending(s => s.PONumber);
            break;
        case "AppropNumber":
            query = query.OrderBy(s => s.AppropNumber);
            break;
        case "AppropNumber_desc":
            query = query.OrderByDescending(s => s.AppropNumber);
            break;
        case "ContractNumber":
            query = query.OrderBy(s => s.ContractNumber);
            break;
        case "ContractNumber_desc":
            query = query.OrderByDescending(s => s.ContractNumber);
            break;
        default: 
            query = query.OrderBy(s => s.PONumber);
            break;
    }
    // Final paginated result
    viewModel.PORequests = query.ToPagedList(pageNumber, 5);
