    Category catAlias = null;
    var test = Session.QueryOver<Company>()
        .Left.JoinAlias(x => x.Category, () => catAlias) // Left is optional
        .WhereRestrictionOn(() => catAlias.Name)
        .IsLike(category.Name);
