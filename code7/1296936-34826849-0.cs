    Tag tagAlias = new Tag();
    Post postAlias = new Post();
    
    Tag tagAliasInner = new Tag();
    Post postAliasInner = new Post();
    
    var subQuery = QueryOver.Of(() => postAliasInner)
    	.JoinAlias(() => postAliasInner.Tags, () => tagAliasInner)
    	.Where(Restrictions.EqProperty(Projections.Property(() => postAliasInner.Id),
    		Projections.Property(() => postAlias.Id)))
    	.Where(Restrictions.In(Projections.Property(() => tagAliasInner.Id), ids.ToArray()))
    	.Select(Projections.Count(Projections.Property(() => tagAliasInner.Id)));
    
    var query = session.QueryOver(() => postAlias)
    	.JoinAlias(() => postAlias.Tags, () => tagAlias)
    	.Where(Restrictions.In(Projections.Property(() => tagAlias.Id), ids.ToArray()))
    	.WithSubquery.WhereValue(ids.Count).Eq<Post>(subQuery);
    
    var results = query.List();
