    // Aliases
    Root rootAlias = null;
    Child x_temp = null;
    Child childAlias = null;
    
    // Result list.
    IList<Root> roots = null;
    
    // Subquery which retrieves a list of child's id by max occurrence and grouping by 
    // root id.
    var subquery = CurrentSession.QueryOver<Child>(() => x_temp)
        .SelectList(list => list
            .Select(() => x_temp.id)
            .SelectMax(() => x_temp.occurrence)
            .SelectGroup(() => x_temp.root.id)
        )
        .List<object[]>()
            .Select(p => p[0]).ToArray();
    // Query root elements, joining with child collection, applying
    // a restriction on child's id attribute through 
    // JoinAlias' "With clause" parameter.
    var query = QueryOver.Of(() => rootAlias).Left.JoinAlias(
        () => rootAlias.childList,
        () => childAlias,
        Restrictions.On(() => childAlias.id).IsIn(subquery)
    );
    
    // retrieves the final result list through the query.
    roots = query.GetExecutableQueryOver(CurrentSession).List();
