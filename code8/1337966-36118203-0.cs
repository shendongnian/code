    var builder = Builders<MongoNavFilter>.Filter;
    var query = builder.Eq(x => x.Link, link) & builder.Eq(x=> x.SubLink, subLink);
    if (some statement)
    {
        var finalExpression = ... // write this using the same syntax 
        query = query & filter; 
    }
    if (onsale)
        query = query & builder.Ne(x=>x.Promo, null) & builder.Ne(x=> x. Promo, string.Empty);
    var filters = _db.GetCollection<MongoNavFilter>("NavFilters").
                    Find(query).ToList();
