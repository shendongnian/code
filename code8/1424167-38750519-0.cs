    var queries = new [] 
    {
        Repository.Query<Product>()
        .Where(p => !p.IsDeleted && p.Article.ArticleSections.Count() > 0)
        .Select(p => new
        {
            OfficeId = p.TariffCategory.Office.Id,
            Office = p.TariffCategory.Office.Name,
            Category = p.TariffCategory.Description,
            ArticleId = p.Article.Id,
            Article = p.Article.Title,
            Destinations = p.ProductDestinations.OrderBy(pd => pd.Destination.Description).Select(pd => new { Id = pd.DestinationId, Name = pd.Destination.Description }),
            GlobalDestinations = p.AllDestinationsInOffice,
            p.Article.LastReviewedDate,
            p.Article.CreatedDate,
            p.Article.CreatedByEmployee
        }),
    
        Repository.Query<Package>()
        .Where(pkg => !pkg.IsDeleted && pkg.Article.ArticleSections.Count() > 0)
        .Select(pkg => new
        {
            OfficeId = pkg.TariffCategory.Office.Id,
            Office = pkg.TariffCategory.Office.Name,
            Category = pkg.TariffCategory.Description,
            ArticleId = pkg.Article.Id,
            Article = pkg.Article.Title,
            Destinations = pkg.PackageDestinations.OrderBy(pd => pd.Destination.Description).Select(pd => new { Id = pd.DestinationId, Name = pd.Destination.Description }),
            GlobalDestinations = pkg.AllDestinationsInOffice,
            pkg.Article.LastReviewedDate,
            pkg.Article.CreatedDate,
            pkg.Article.CreatedByEmployee
        }),
    
        Repository.Query<Backgrounder>()
        .Where(bkgd => !bkgd.IsDeleted && bkgd.Article.ArticleSections.Count() > 0)
        .Select(bkgd => new
        {
            OfficeId = bkgd.TariffCategory.Office.Id,
            Office = bkgd.TariffCategory.Office.Name,
            Category = bkgd.TariffCategory.Description,
            ArticleId = bkgd.Article.Id,
            Article = bkgd.Article.Title,
            Destinations = bkgd.BackgrounderDestinations.OrderBy(bd => bd.Destination.Description).Select(bd => new { Id = bd.DestinationId, Name = bd.Destination.Description }),
            GlobalDestinations = bkgd.AllDestinationsInOffice,
            bkgd.Article.LastReviewedDate,
            bkgd.Article.CreatedDate,
            bkgd.Article.CreatedByEmployee
        }),
    };
    
    // Apply filters
    if (OfficeIds.Any())
        for (int i = 0; i < queries.Length; i++) queries[i] = queries[i].Where(a => OfficeIds.Contains(a.OfficeId));
    if (DestinationIds.Any())
        for (int i = 0; i < queries.Length; i++) queries[i] = queries[i].Where(a => a.GlobalDestinations || a.Destinations.Any(d => DestinationIds.Contains(d.Id)));
    if (!string.IsNullOrEmpty(ArticleTitle))
        for (int i = 0; i < queries.Length; i++) queries[i] = queries[i].Where(a => a.Article.Contains(ArticleTitle));
    if (!string.IsNullOrEmpty(TariffCategory))
        for (int i = 0; i < queries.Length; i++) queries[i] = queries[i].Where(a => a.Category.Contains(TariffCategory));
    
    // Switch to LINQ to Objects and concatenate the results
    var result = queries.Select(query => query.AsEnumerable()).Aggregate(Enumerable.Concat);
    
    // Sort results
    result = result.OrderBy(a=> a.Office).ThenBy(a => a.Category).ThenBy(a => a.Article);
    
    var articles = result.ToList();
