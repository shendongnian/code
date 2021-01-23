    var query = Session.QueryOver<Asset>();
    
    if (!string.IsNullOrEmpty(title))
        query = query.WhereRestrictionOn(x => x.Title).IsLike(title, MatchMode.Anywhere);
    
    if (!string.IsNullOrEmpty(productNumber))
    {
        query = query.JoinQueryOver(a => a.Products).Where(p => p.Id == productNumber);
    }
    
    var result = query.List<Asset>();
