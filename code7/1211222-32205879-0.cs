    var query = this.DbContext.RecipeTranslations
                .Where(x => x.Language.Code == this.CurrentLanguge)
                .Where(x => string.IsNullOrEmpty(name) || x.Title.Contains(name))
                .Select(x => x.Recipe)
                .Where(x => x.IsDeleted == false)
                .Where(x => category == null || x.Categories.Any(cat => cat.Id == category));
    
    if (order == 1)
    {
        query = query.OrderByDescending(byRank);
    }
    else if (order == 2)
    {
        query = query.OrderByDescending(byPopularity);
    }
    else
    {
        query = query.OrderByDescending(byCreatedOn);
    }
    
    // Finally
    var list = query.Skip(start).Take(size).toList();
    
