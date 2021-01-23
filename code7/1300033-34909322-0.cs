    IQueryable<Identifier> query = null;
    foreach (var item in identifiers.Where(i => !i.IsMarkedForDeletion))
    {
    	var i = item;
    	var subquery = this.MyEntities.Identifiers.Where(pi => 
            pi.Field1 == i.Field1 && pi.Field2 == i.Field2 && pi.Field3 == i.Field3);
        query = query != null ? query.Concat(subquery) : subquery;
    }
    bool result = query != null && query.Any();
